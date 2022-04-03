import { useEffect, useState } from "react";
import Calendar from "react-calendar";
import { Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { Show } from "../../app/models/Show";
import ShowList from "./ShowList";


const ShowListDashboard = () => {

    const [shows, setShows] = useState<Show[]>([])

    useEffect(() => {
        var date = new Date;
        fetchShows(date);
    }
        , []);

    const fetchShows = (date: Date) => {
        agent.Shows.list(date.toISOString())
            .then((shows) => {
                setShows(shows.shows);
            }
            )
    }

    return (
        <>
            <Grid>
                <Grid.Row />
                <Grid.Column width='16'>
                    <Header as='h1' dividing textAlign="center">
                        Select show to book a ticket
                    </Header>
                </Grid.Column>
                <Grid.Row />
                <Grid.Column width='1' />
                <Grid.Column width='10'>
                    <ShowList shows={shows} />
                </Grid.Column>
                <Grid.Column width='4'>
                    <Calendar onClickDay={date => fetchShows(date)} />
                </Grid.Column>
            </Grid>
        </>
    )
}

export default ShowListDashboard;