import { SeatPosition } from "./Seat";

export interface UserTicket {
    id: string,
    showId: string,
    movieTitle: string,
    showDate: Date,
    seats: SeatPosition[]
}

export interface UserTickets{
    tickets: UserTicket[]
}