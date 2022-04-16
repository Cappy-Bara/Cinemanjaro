import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Image, Header, Grid, Label, Divider, Statistic, Button, Container } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { Movie } from "../../app/models/Movie";
import './styles.css';


const MoviePage = () => {

    const { id } = useParams<{ id: string }>();
    const [movie, setMovie] = useState<Movie>();

    const fetchMovieDetails = () => {
        agent.Movies.details(id ?? "").then(fetchedMovie =>
            setMovie(fetchedMovie))
    }

    useEffect(() => {
        fetchMovieDetails();
    }, [])


    return (
        <>
            <Grid>
                <Grid.Column width='16'>
                    <Header as='h1'>
                        {movie?.title} ({movie?.releaseYear})
                        {movie?.genres.map(x => <Label className='float-right' color="blue">{x}</Label>)}
                    </Header>
                    <Divider />
                </Grid.Column>
                <Grid.Column width='8' >
                    <Image src='https://fwcdn.pl/fph/94/76/469476/924841_1.3.jpg' size="big" />

                        <Statistic>
                            <Statistic.Value>{movie?.rate}/10</Statistic.Value>
                            <Statistic.Label>RATE</Statistic.Label>
                        </Statistic>

                        <Container className="sameline">
                            <Button
                                color="yellow"
                                content='IMDb'
                                as='a'
                                href={movie?.imdbLink}
                                target="_blank"
                            />
                            <Button
                                color="yellow"
                                content='Filmweb'
                                as='a'
                                href={movie?.filmwebLink}
                                target="_blank" />
                        </Container>

                </Grid.Column>
                <Grid.Column width='8'>

                    <Header as='h3'>Description:</Header>
                    <p>
                        {movie?.description}
                    </p>

                    <Header as='h3'>Starring:</Header>
                    <p>
                        {movie?.actors.join(', ')}
                    </p>

                    <Header as='h3'>Dirrected By:</Header>
                    <p>
                        {movie?.directors.join(', ')}
                    </p>

                    <Header as='h3'>Written By:</Header>
                    <p>
                        {movie?.writers.join(', ')}
                    </p>

                    <Header as='h3'>Time:</Header>
                    <p>
                        {((movie?.lengthMins ?? 0) / 60).toString()[0]}h <span></span>
                        {((movie?.lengthMins ?? 0) % 60)}min
                    </p>
                </Grid.Column>
            </Grid>
        </>
    )
}

export default MoviePage;