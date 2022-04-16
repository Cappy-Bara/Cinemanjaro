import { Link } from "react-router-dom"
import { Button, Grid, Header, Message } from "semantic-ui-react"
import { Seat } from "../../../app/models/Seat"
import { ShowDetails } from "../../../app/models/Show"
import SeatsList from "../BookSeatsScreen/SeatsList"
import SelectedSeats from "../BookSeatsScreen/SelectedSeats"

interface props {
    setSeats : React.Dispatch<React.SetStateAction<Seat[]>>
    chosenSeats: Seat[],
    showDetails : ShowDetails,
    setIsFirstStep : React.Dispatch<React.SetStateAction<Boolean>>
}

const BookSeatsFirstStep = ({setSeats,chosenSeats,showDetails,setIsFirstStep}:props) => {

    const addSeatToBooked = (seat: Seat) => {
        setSeats([...chosenSeats, seat]);
    }
    
    const removeSeatFromBooked = (seat: Seat) => {
        let arr = chosenSeats.filter(x => x !== seat);
        setSeats(arr);
    }

    return (
        <>
            <Grid>
                <Grid.Column width='16'>
                    <Header as='h1' dividing textAlign="center">
                        Select seats
                    </Header>
                </Grid.Column>
                <Grid.Row />
                <Grid.Column width='1' />
                <Grid.Column width='10'>
                    <SeatsList chosenSeats={chosenSeats} setSeat={addSeatToBooked} removeSeat={removeSeatFromBooked} seats={showDetails?.seats ?? []} />
                </Grid.Column>
                <Grid.Column width='5'>
                    <Header as='h2'>Selected seats:</Header>
                    {chosenSeats?.length > 0 ?
                        <SelectedSeats seats={chosenSeats} />
                        :
                        <Message
                            header="You haven't chosen any seat at this moment."
                            content='Please select a seat to continue.'
                        />
                    }
                    <Grid.Row></Grid.Row>
                    <Button
                        primary
                        floated='right'
                        onClick={() => setIsFirstStep(false)}
                        disabled={chosenSeats?.length <= 0 ?? false}
                    >
                        Book seats
                    </Button>
                    <Button
                        as={Link}
                        to={`/shows`}
                    >
                        Back
                    </Button>
                </Grid.Column>
            </Grid>
        </>
    )

}

export default BookSeatsFirstStep