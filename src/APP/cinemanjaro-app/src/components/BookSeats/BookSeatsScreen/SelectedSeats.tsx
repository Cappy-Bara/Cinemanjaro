import { List } from "semantic-ui-react";
import { Seat } from "../../../app/models/Seat"

interface props {
    seats: Seat[]
}



const SelectedSeats = ({ seats }: props) => {
    {
        return (
                <List bulleted>
                    {
                        seats.map(seat => {
                            return (<List.Item key={seat.number.toString() + seat.row.toString()}>Row {seat.row} - Number {seat.number}</List.Item>)
                        })
                    }
                </List>
            )
    }
}

export default SelectedSeats
