import { Checkbox, Item, Label, Segment, SemanticCOLORS } from "semantic-ui-react";
import { Seat, SeatStatus } from "../../../app/models/Seat";
import './styles.css';

interface props {
    seat: Seat,
    setSeat: (seat: Seat) => void,
    removeSeat: (seat: Seat) => void,
    chosenSeats : Seat[]
}

const getLabelColor = (label: SeatStatus): SemanticCOLORS => {
    return label == SeatStatus.Free ? 'blue' : 'red';
}
const SeatList = ({ seat, setSeat, removeSeat, chosenSeats }: props) => {


    const isChecked  = (seat : Seat): boolean => {
        var chosenSeat = chosenSeats.find(x => x.number == seat.number && x.row == seat.row);
        return !!chosenSeat;
    } 

    return (
        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item>
                        <Item.Content>
                            <Item.Header as='a'>ROW {seat.row} - NUMBER {seat.number}</Item.Header>
                            <Item.Extra>
                                <Checkbox
                                    checked= {isChecked(seat)}
                                    className="checkbox-right"
                                    disabled={seat.status === SeatStatus.Occupied}
                                    onChange={(e,d) =>{
                                        d.checked ? setSeat(seat) : removeSeat(seat)
                                    }}
                                />
                                <Label
                                    color={getLabelColor(seat.status)}>{SeatStatus[seat.status]}
                                </Label>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
        </Segment.Group>
    )
}

export default SeatList;