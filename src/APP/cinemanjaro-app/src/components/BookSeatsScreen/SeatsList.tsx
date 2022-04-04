import { Message } from "semantic-ui-react";
import { Seat } from "../../app/models/Seat";
import SeatListElement from "./SeatListElement";

interface props {
    seats : Seat[],
}

const SeatList = ({seats}:props) => {

    return(
        <>
                    {
                seats ?
                    (
                    seats.map(seat =>
                        <SeatListElement key={seat.number.toString() + seat.row.toString()} seat={seat} />
                    )
                    )
                    :
                    <Message
                        icon='ticket'
                        header="Unfortunately, we don't have any seats for this seanse."
                        content='Please select different seanse.'
                  />
            }
        </>
    )


}

export default SeatList;