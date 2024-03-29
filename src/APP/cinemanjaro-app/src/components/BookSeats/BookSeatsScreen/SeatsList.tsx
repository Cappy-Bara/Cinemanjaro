import { Message } from "semantic-ui-react";
import { Seat } from "../../../app/models/Seat";
import SeatListElement from "./SeatListElement";

interface props {
    seats: Seat[],
    setSeat: (seat: Seat) => void,
    removeSeat: (seat: Seat) => void,
    chosenSeats: Seat[],
}

const SeatList = ({ seats, setSeat, removeSeat, chosenSeats }: props) => {

    return (
        <>
            {
                seats ?
                    (
                        seats.map(seat =>
                            <SeatListElement
                                chosenSeats={chosenSeats}
                                key={seat.number.toString() + seat.row.toString()}
                                seat={seat}
                                setSeat={setSeat}
                                removeSeat={removeSeat}
                            />
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