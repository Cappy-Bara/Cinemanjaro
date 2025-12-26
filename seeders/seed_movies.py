#USED DATASET -> https://www.kaggle.com/datasets/rounakbanik/the-movies-dataset/data?select=links_small.csv
#EXTRACT IN seeders/data/*

from pyspark.sql import SparkSession
from pyspark.sql.functions import udf, col, year, concat, lit, expr, array_except, transform, when, lit, array
from pyspark.sql.types import ArrayType, StructType, StructField, StringType, IntegerType
import ast

UNWANTED_GENRES = [
"Aniplex",
"BROSTA TV",
"Carousel Productions",
"GoHands",
"Mardock Scramble Production Committee",
"Odyssey Media",
"Pulser Productions",
"Rogue State",
"Sentai Filmworks",
"TV Movie",
"Telescene Film Group Productions",
"The Cartel",
"Vision View Entertainment"
]

GENRE_REMAP = {
    "Science Fiction": "SciFi",
}

def parse_genres(genres_str):
    if not genres_str:
        return []
    try:
        genres = ast.literal_eval(genres_str)
        return [g["name"] for g in genres]
    except:
        return []
    
def parse_cast(cast_str):
    try:
        data = ast.literal_eval(cast_str)
        return [
            {
                "name": x.get("name"),
                "character": x.get("character"),
                "order": x.get("order")
            }
            for x in data
        ]
    except:
        return []

def parse_crew(crew_str):
    try:
        data = ast.literal_eval(crew_str)
        return [
            {
                "name": x.get("name"),
                "department": x.get("department"),
                "job": x.get("job")
            }
            for x in data
        ]
    except:
        return []

def clean_and_remap_genres(col_expr):
    # Remove unwanted genres
    cleaned = array_except(col_expr, array(*[lit(g) for g in UNWANTED_GENRES]))

    # Remap genres
    remapped = cleaned
    for k, v in GENRE_REMAP.items():
        remapped = transform(remapped, lambda g: when(g == k, v).otherwise(g))
    
    return remapped


spark = (
    SparkSession.builder
    .appName("SeedMovies")
    .config(
        "spark.jars.packages",
        "org.mongodb.spark:mongo-spark-connector_2.12:10.4.0"
    )
    .config("spark.mongodb.write.connection.uri", "mongodb://cinemanjaro:passwd23467@localhost:2717")
    .config("spark.mongodb.write.database", "cinemanjaro_movies")
    .config("spark.mongodb.write.collection", "movies")
    .getOrCreate()
)

df = spark.read \
    .option("header", True) \
    .option("multiLine", True) \
    .option("escape", "\"") \
    .option("quote", "\"") \
    .csv("data/short_movies_metadata.csv")

credits_df = spark.read \
    .option("header", True) \
    .option("multiLine", True) \
    .option("quote", "\"") \
    .option("escape", "\"") \
    .option("mode", "PERMISSIVE") \
    .csv("data/short_credits.csv")

cast_schema = ArrayType(
    StructType([
        StructField("name", StringType()),
        StructField("character", StringType()),
        StructField("order", IntegerType())
    ])
)

crew_schema = ArrayType(
    StructType([
        StructField("name", StringType()),
        StructField("department", StringType()),
        StructField("job", StringType())
    ])
)

parse_cast_udf = udf(parse_cast, cast_schema)
parse_crew_udf = udf(parse_crew, crew_schema)

#parse JSONs
credits_df = credits_df \
    .withColumn("cast_arr", parse_cast_udf(col("cast"))) \
    .withColumn("crew_arr", parse_crew_udf(col("crew")))

actors_df = credits_df.select(
    col("id"),
    expr("transform(cast_arr, x -> x.name)").alias("Actors")
)

directors_df = credits_df.select(
    col("id"),
    expr("transform(filter(crew_arr, x -> x.job = 'Director'), x -> x.name)").alias("Directors")
)

writers_df = credits_df.select(
    col("id"),
    expr("transform(filter(crew_arr, x -> x.department = 'Writing'), x -> x.name)").alias("Writers")
)

credits_enriched_df = actors_df \
    .join(directors_df, "id", "left") \
    .join(writers_df, "id", "left")


parse_genres_udf = udf(parse_genres, ArrayType(StringType()))


movies_out = df.select(

    col("id"),  # ← KEEPED FOR JOINING

    # Title
    col("title").alias("Title"),

    # Description
    col("overview").alias("Description"),

    # Genres
    clean_and_remap_genres(parse_genres_udf(col("genres"))).alias("Genres"),

    # Length
    col("runtime").cast("float").cast("int").alias("LengthMins"),

    # Rate
    col("vote_average").cast("double").alias("Rate"),

    # IMDB link
    concat(
        lit("https://www.imdb.com/title/"),
        col("imdb_id"),
        lit("/")
    ).alias("IMDBLink"),

    # Release year
    year(col("release_date")).alias("ReleaseYear"),

    # Photo URL
    concat(
        lit("https://image.tmdb.org/t/p/w500"),
        col("poster_path")
    ).alias("PhotoURL")
)

movies_final_df = movies_out.join(
    credits_enriched_df,
    on="id",
    how="left"
).drop("id")

movies_final_df.write \
    .format("mongodb") \
    .mode("append") \
    .save()