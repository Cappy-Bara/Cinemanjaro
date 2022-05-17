import { SeatPosition } from "./Seat";

export interface UserTickets {
    id: string,
    showId: string,
    movieTitle: string,
    showDate: Date,
    seats: SeatPosition
}
