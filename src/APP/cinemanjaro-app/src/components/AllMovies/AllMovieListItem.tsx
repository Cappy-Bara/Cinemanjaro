import { Card } from "semantic-ui-react";
import { AllMoviesListElementData } from "../../app/models/Movie";
import { useNavigate } from "react-router";

interface Props {
    movies: AllMoviesListElementData[];
}

const AllMoviesItem = ({ movies }: Props) => {
    const navigate = useNavigate();

    return (
        <Card.Group itemsPerRow={5} stackable>
            {movies.map(movie => (
                <Card
                    key={movie.id}
                    onClick={() => navigate(`/movies/${movie.id}`)}
                    link
                >
                    <img src={movie.photoURL} alt={movie.title} />
                    <Card.Content>
                        <Card.Header>{movie.title}</Card.Header>
                    </Card.Content>
                </Card>
            ))}
        </Card.Group>
    );
};

export default AllMoviesItem;
