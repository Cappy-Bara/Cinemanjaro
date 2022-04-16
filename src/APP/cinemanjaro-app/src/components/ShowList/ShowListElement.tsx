import { Button, Item, ItemGroup, Label, Segment } from "semantic-ui-react";
import { Show } from "../../app/models/Show";
import dateFormat from 'dateformat'
import { Link, useNavigate } from "react-router-dom";

interface props {
  show: Show
}

const ShowListElement = ({ show }: props) => {

  const navigate = useNavigate();

  return (
    <Segment.Group>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image size="tiny" src={show.iconURL} />
            <Item.Content>
              <Item.Header as='a' onClick={() => navigate(`/movies/${show.movieId}`)}>{show.title}</Item.Header>
              <Item.Meta>
                <span className='cinema'>{((show.lengthMins ?? 0) / 60).toString()[0]}h {((show.lengthMins ?? 0) % 60)}min</span>
              </Item.Meta>
              <Item.Description>{dateFormat(show.date, "dd.mm.yyyy / H.MM", true)}</Item.Description>
              <Item.Extra>
                <Button
                  as={Link}
                  to={`/shows/${show.id}`}
                  floated='right'
                  primary
                >
                  Buy tickets
                </Button>
                {show.genres.map(genre => <Label>{genre}</Label>)}
              </Item.Extra>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
    </Segment.Group>
  )

}

export default ShowListElement;