import { Checkbox, Item, Label, Segment, SemanticCOLORS } from "semantic-ui-react";
import { Seat, SeatStatus } from "../../app/models/Seat";
import './styles.css';

interface props {
    seat: Seat,
}

const getLabelColor = (label: SeatStatus): SemanticCOLORS => {
    return label == SeatStatus.Free ? 'blue' : 'red';
}
const SeatList = ({ seat }: props) => {

    return (
        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item>
                        <Item.Content>
                            <Item.Header as='a'>ROW {seat.row} - NUMBER {seat.number}</Item.Header>
                            <Item.Extra>
                                <Checkbox 
                                    className="checkbox-right" 
                                    disabled = {seat.status === SeatStatus.Occupied}
                                    />
                                <Label color={getLabelColor(seat.status)}>{SeatStatus[seat.status]}</Label>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
        </Segment.Group>
    )
}

export default SeatList;