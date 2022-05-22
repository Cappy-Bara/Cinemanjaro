import dateFormat from 'dateformat';
import { Button, Icon, List, Modal } from 'semantic-ui-react'
import { UserTicket } from '../../app/models/Ticket';

interface props {
    setOpen: React.Dispatch<React.SetStateAction<boolean>>;
    open: boolean;
    ticket: UserTicket;
}

const TicketModal = ({ open, setOpen, ticket }: props) => {

    return (
        <Modal
            onClose={() => setOpen(false)}
            onOpen={() => setOpen(true)}
            open={open}
        >
            <Modal.Header>Ticket Details</Modal.Header>
            <Modal.Content image>
                <Icon size='huge' name='ticket' />
                <Modal.Description>
                    <List>
                        <List.Item>
                            <List.Header>Movie Title:</List.Header>{ticket.movieTitle}
                        </List.Item>
                        <List.Item>
                            <List.Header>Date:</List.Header>
                            {dateFormat(ticket.showDate, "dd.mm.yyyy", true)}
                        </List.Item>
                        <List.Item>
                            <List.Header>Hour:</List.Header>
                            {dateFormat(ticket.showDate, "H.MM", true)}
                        </List.Item>
                        <List.Item>
                            <List.Header>Seats:</List.Header>
                            <List horizontal>
                                {
                                    ticket.seats.map((seat, index) => {
                                        return (<List.Item key={index}>
                                            <List.Content>
                                                <List.Header>Seat {index + 1}</List.Header>
                                                Row: {seat.row}, Number: {seat.number}
                                            </List.Content>
                                        </List.Item>)
                                    })
                                }
                            </List>
                        </List.Item>
                    </List>
                </Modal.Description>
            </Modal.Content>
            <Modal.Actions>
                <Button onClick={() => setOpen(false)}>Close</Button>
            </Modal.Actions>
        </Modal>
    )
}

export default TicketModal