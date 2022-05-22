import { Header } from "semantic-ui-react";
import TicketList from "./TicketList";

const UserTicketsScreen = () => {

    return (
        <>
            <Header as='h1' dividing textAlign="center">
                Your Tickets
            </Header>

            <TicketList/>
        </>
    )
}

export default UserTicketsScreen;