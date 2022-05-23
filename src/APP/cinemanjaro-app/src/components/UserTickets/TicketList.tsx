import { useEffect, useState } from "react";
import { Header, Message } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { UserTicket } from "../../app/models/Ticket";
import TicketListElement from "./TicketListElement";

const TicketList = () => {

    const [userTickets, setUserTickets] = useState<UserTicket[]>([]);

    useEffect(() => {
        agent.Tickets.AllUserTickets().then((output) => {
            setUserTickets(output.tickets);
        })
    }, [])

    return (
        <>
            {userTickets.length ?
                userTickets.map(ticket => <TicketListElement ticket={ticket} />)
                :
                <Message
                    icon='ticket'
                    header="You don't have any tickets yet."
                    content='Go ahead and book some seats!'
                />}
        </>
    )
}

export default TicketList;