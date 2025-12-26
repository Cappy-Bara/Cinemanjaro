from pyspark.sql import SparkSession
from pyspark.sql.functions import udf, col, explode, expr
from pyspark.sql.types import ArrayType, StringType
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
        return [g["name"] for g in genres if "name" in g]
    except Exception:
        return []

def genre_remap_case():
    cases = "\n".join(
        [f"WHEN g = '{k}' THEN '{v}'" for k, v in GENRE_REMAP.items()]
    )
    return f"""
        CASE
            {cases}
            ELSE g
        END
    """

def clean_and_remap_genres(col_name="Genres"):
    unwanted = ",".join(f"'{g}'" for g in UNWANTED_GENRES)
    remap_case = genre_remap_case()

    return expr(f"""
        transform(
            filter(
                transform({col_name}, g -> trim(g)),
                g -> g IS NOT NULL
                     AND g != ''
                     AND NOT array_contains(array({unwanted}), g)
            ),
            g -> {remap_case}
        )
    """)

parse_genres_udf = udf(parse_genres, ArrayType(StringType()))

spark = (
    SparkSession.builder
    .appName("GetGenres")
    .getOrCreate()
)

df = spark.read \
    .option("header", True) \
    .option("multiLine", True) \
    .option("escape", "\"") \
    .option("quote", "\"") \
    .csv("data/movies_metadata.csv")

genres_df = (
    df
        .withColumn("parsed", parse_genres_udf(col("genres")))
        .withColumn("Genres", clean_and_remap_genres("parsed"))
        .select(explode(col("Genres")).alias("genre"))
        .distinct()
        .orderBy("genre")
)

(
    genres_df
        .coalesce(1)
        .write
        .mode("overwrite")
        .text("data/output/genres_txt")
)
