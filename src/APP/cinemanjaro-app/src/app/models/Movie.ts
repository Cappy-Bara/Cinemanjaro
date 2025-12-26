export interface Movie {
    id: string,
    title: string,
    description: string,
    directors: string[],
    actors: string[],
    genres: string[],
    writers: string[],
    lengthMins: 0,
    rate: 0,
    releaseYear: 0,
    imdbLink: string,
    photoURL: string,
}

export interface MoviesResponse{
    movies:MovieListElementData[]
}

export interface MovieListElementData{
    id:string,
    iconURL:string,
    genres:string[],
    title:string
}

export interface AllMoviesResponse{
    movies:AllMoviesListElementData[]
    amount:number
}

export interface AllMoviesListElementData{
    id:string,
    title:string,
    photoURL:string
}