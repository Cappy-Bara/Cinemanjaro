import { Button, Item, ItemGroup, Label, Segment} from "semantic-ui-react";
import { Show } from "../../app/models/Show";

interface props {
  show: Show
}

const ShowListElement = ({ show }: props) => {

  return (
          <Segment.Group>
          <Segment>
          <Item.Group>
          <Item>
            <Item.Image src='https://react.semantic-ui.com/images/wireframe/image.png' />
            <Item.Content>
              <Item.Header as='a'>{show.Title}</Item.Header>
              <Item.Meta>
                <span className='cinema'>1h 45min</span>
              </Item.Meta>
              <Item.Description>{show.Date.toISOString()}</Item.Description>
              <Item.Extra>
                <Button floated='right' primary>
                  Buy tickets
                </Button>
                <Label>Comedy</Label>
                <Label>Romantic</Label>
                <Label>Drama</Label>
              </Item.Extra>
            </Item.Content>
          </Item>
          </Item.Group>
          </Segment>
          </Segment.Group>

  )

}

export default ShowListElement;