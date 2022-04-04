import { useEffect, useState } from "react";
import { Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { ShowDetails } from "../../app/models/Show";
import SeatsList from "./SeatsList";


const BookSeatsDashboard = () => {

    const [showDetails,setShowDetails] = useState<ShowDetails>()

    const fetchShowDetails = () => {
        agent.Shows.details("62457e6f5c59433c60580bdb").then(fetchedShow =>
            setShowDetails(fetchedShow))
    }

    useEffect(() => {
        fetchShowDetails();
    },[])


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
                    <SeatsList seats={showDetails?.seats ?? []}/>
                </Grid.Column>
            </Grid>
        </>
    )
}

export default BookSeatsDashboard;