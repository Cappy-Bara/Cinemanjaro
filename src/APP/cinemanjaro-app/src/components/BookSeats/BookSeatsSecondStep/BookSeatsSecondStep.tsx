import dateFormat from "dateformat"
import { useState } from "react"
import { Grid, Header, Item, Image, Segment, Button, Input, Checkbox, Divider } from "semantic-ui-react"
import agent from "../../../app/api/agent"
import { Seat } from "../../../app/models/Seat"
import { SeatsToBook, ShowDetails } from "../../../app/models/Show"
import { SeatPosition} from "../../../app/models/Seat"
import SelectedSeats from "../BookSeatsScreen/SelectedSeats"
import { useNavigate } from "react-router-dom"


interface props {
    showDetails: ShowDetails,
    selectedSeats: Seat[],
    setIsFirstStep: React.Dispatch<React.SetStateAction<Boolean>>
}

const BookSeatsSecondStep = ({ showDetails, selectedSeats, setIsFirstStep }: props) => {

    const [email, setEmail] = useState<string>("");
    const navigate = useNavigate();

    const bookTickets = () => {
        const positions = selectedSeats.map(seat => ({row: seat.row,number: seat.number} as SeatPosition));
        const seats : SeatsToBook = {
            email: email,
            seatPositions: positions,
        };
        agent.Shows.bookSeats(showDetails.id,seats).then(x => navigate("/success"))
    }


    return (
        <>
            <Grid>
                <Grid.Column width='16'>
                    <Header as='h1' textAlign="center" dividing>
                        Buy tickets
                    </Header>
                </Grid.Column>
                <Grid.Row>

                    <Grid.Column width={8} stretched>
                        <Segment>
                            <Header as='h3' textAlign="center">Show</Header>
                            <Item.Group>
                                <Item>
                                    <Item.Image size='tiny' src={showDetails.iconURL} />
                                    <Item.Content>
                                        <Item.Header as='a' onClick={() => navigate(`/movies/${showDetails.movieId}`)}>{showDetails.title}</Item.Header>
                                        <Item.Meta>{dateFormat(showDetails.date, "dd.mm.yyyy", true)}</Item.Meta>
                                        <Item.Meta>{dateFormat(showDetails.date, "H.MM", true)}</Item.Meta>
                                    </Item.Content>
                                </Item>
                            </Item.Group>
                            <Divider />
                            <Header as='h3' textAlign="center">Seats</Header>
                            <SelectedSeats seats={selectedSeats} />

                        </Segment>
                    </Grid.Column>

                    <Grid.Column width={8} stretched>
                        <Segment>
                            <Header as='h3' textAlign="center">Enter customer data</Header>
                            <Input
                                placeholder="Email"
                                onChange={(e, d) => setEmail(d.value)}
                            />
                        </Segment>
                    </Grid.Column>
                </Grid.Row>
                <Grid.Column width='16'>
                    <Button
                        primary
                        floated='right'
                        onClick={() => bookTickets()}
                        disabled={email?.length <= 0 ?? false}
                    >
                        Book seats
                    </Button>
                    <Button
                        onClick={() => setIsFirstStep(true)}
                    >
                        Back
                    </Button>
                </Grid.Column>
            </Grid>
        </>
    )
}

export default BookSeatsSecondStep