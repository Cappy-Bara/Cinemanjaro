import { useEffect, useState } from "react";
import { Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { UserTicket } from "../../app/models/Ticket";
import TicketListElement from "./TicketListElement";

const TicketList = () => {

    const [userTickets, setUserTickets] = useState<UserTicket[]>([]);

    useEffect(() => {
        agent.Tickets.AllUserTickets().then((output) => {
            setUserTickets(output.tickets);
        })
    },[])

    return (
        <>
            {userTickets.map(ticket => <TicketListElement ticket={ticket}/>)}
        </>
    )
}

export default TicketList;