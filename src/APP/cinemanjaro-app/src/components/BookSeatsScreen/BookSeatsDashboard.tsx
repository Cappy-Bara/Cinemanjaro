import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { Button, Grid, Header, List, Message } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { Seat } from "../../app/models/Seat";
import { ShowDetails } from "../../app/models/Show";
import SeatsList from "./SeatsList";
import './styles.css'

const BookSeatsDashboard = () => {

    const [showDetails, setShowDetails] = useState<ShowDetails>()
    const [chosenSeats, setChosenSeats] = useState<Seat[]>([])

    const { id } = useParams<{ id: string }>();

    const fetchShowDetails = () => {
        agent.Shows.details(id ?? "").then(fetchedShow =>
            setShowDetails(fetchedShow))
    }

    useEffect(() => {
        fetchShowDetails();
    }, [])

    const addSeatToBooked = (seat: Seat) => {
        setChosenSeats([...chosenSeats, seat]);
    }

    const removeSeatFromBooked = (seat: Seat) => {
        let arr = chosenSeats.filter(x => x !== seat);
        setChosenSeats(arr);
    }

    return (
        <>
            <Grid>
                <Grid.Row />
                <Grid.Column width='16'>
                    <Header as='h1' dividing textAlign="center">
                        Select seats
                    </Header>
                </Grid.Column>
                <Grid.Row />
                <Grid.Column width='1' />
                <Grid.Column width='10'>
                    <SeatsList setSeat={addSeatToBooked} removeSeat={removeSeatFromBooked} seats={showDetails?.seats ?? []} />
                </Grid.Column>
                <Grid.Column width='5'>
                    <Header as='h2'>Selected seats:</Header>
                    {chosenSeats?.length > 0 ?
                        <List bulleted>
                            {
                                chosenSeats.map(seat => {
                                    return (<List.Item key={seat.number.toString() + seat.row.toString()}>Row {seat.row} - Number {seat.number}</List.Item>)
                                })
                            }
                        </List>
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

export default BookSeatsDashboard;