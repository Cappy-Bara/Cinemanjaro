import { useNavigate } from "react-router";
import { Item, Label, Segment } from "semantic-ui-react";
import { MovieListElementData } from "../../app/models/Movie";

interface props {
    movieData : MovieListElementData
}



const MovieList = ({movieData}:props) => {

    const navigate = useNavigate();

    return (
            <Segment.Group>
                <Segment>
                    <Item.Group>
                        <Item>
                            <Item.Image size="tiny" src={movieData.iconURL} />
                            <Item.Content>
                                <Item.Header as='a' onClick={() => navigate(`/movies/${movieData.id}`)}>{movieData.title}</Item.Header>
                                <Item.Description>
                                    {movieData.genres.map(genre => <Label>{genre}</Label>)}
                                </Item.Description>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment.Group>
    )



}

export default MovieList;