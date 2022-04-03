import { useEffect, useState } from "react";
import Calendar from "react-calendar";
import { Grid } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { Show } from "../../app/models/Show";
import ShowList from "./ShowList";


const ShowListDashboard = () => {
    
    const show1 : Show = {
        Id: "624969106f597e85cc7690da",
        Date: new Date(2022,10,11,13,30),
        Title: "Dune"
    }
    
    const show2 : Show = {
        Id: "6249691843db562bcdd91847",
        Date: new Date(2022,3,11,18,30),
        Title: "Star Wars"
    }
    
    const [shows, setShows] = useState<Show[]>([show1,show2])
    
    useEffect(() => {
        console.log(agent.Tests.testGet());
        var date = new Date;
        fetchShows(date);
    }
    ,[]);

    const fetchShows = (date : Date) => {
        agent.Shows.list(date.toISOString())
            .then((shows) => {
                setShows(shows);
            }
        )
    }

    return(
    <>
    <Grid>
        <Grid.Row />
        <Grid.Column width='1' />
        <Grid.Column width='10'>
            <ShowList shows={shows}/>
        </Grid.Column>    
        <Grid.Column width='4'>
            <Calendar onClickDay={date => fetchShows(date)}/>
        </Grid.Column>
    </Grid>
    </>
    )
}

export default ShowListDashboard;