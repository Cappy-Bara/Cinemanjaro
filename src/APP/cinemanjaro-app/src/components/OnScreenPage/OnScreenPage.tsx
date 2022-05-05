import { useEffect, useState } from "react";
import { Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { MovieListElementData } from "../../app/models/Movie";
import MovieList from "./MovieList";




const OnScreenPage = () => {

    const [movies,setMovies] = useState<MovieListElementData[]>();

    const fetch = () => {
        agent.Movies.list().then(data =>
            {
                setMovies(data.movies);
            }
        )
    }

    useEffect(() => {
        fetch();
    },[])


    return(
    <Grid>
        <Grid.Column width='16'>
            <Header as='h1' dividing textAlign="center">
                Currently On Screen
            </Header>
        </Grid.Column>
        <Grid.Row />
        <Grid.Column width='16'>
            {movies && movies.map(movie => <MovieList movieData={movie}/>)}
        </Grid.Column>
    </Grid>)
}

export default OnScreenPage;