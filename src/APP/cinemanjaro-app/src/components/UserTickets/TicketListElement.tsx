import dateFormat from "dateformat";
import { useState } from "react";
import { useNavigate } from "react-router";
import { Button, Icon, Item, Modal, Segment } from "semantic-ui-react";
import { UserTicket } from "../../app/models/Ticket";
import TicketModal from "./TicketModal";

interface props {
    ticket: UserTicket
}

const TicketListElement = ({ ticket }: props) => {
    const navigate = useNavigate();
    const [open, setOpen] = useState(false)

    return (
        <>
            <Segment.Group>
                <Segment>
                    <Item.Group>
                        <Item>
                            <Item.Content>
                                <Item.Header>{ticket.movieTitle}</Item.Header>
                                <Item.Description>{dateFormat(ticket.showDate, "dd.mm.yyyy / H.MM", true)}</Item.Description>
                            </Item.Content>
                            <div onClick={() => setOpen(true)}>
                                <Icon name="eye" size="big" style={{cursor:'pointer'}}/>
                            </div>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment.Group>

            <TicketModal open={open} setOpen={setOpen} ticket={ticket}/>
        </>
    )
}

export default TicketListElement;