import { Seat, SeatPosition } from "./Seat";

export interface Show{
    Id : string,
    Date : Date,
    Title : string,
}

export interface ShowDetails{
    Id : string,
    Date : Date,
    Title : string,
    Seats : Seat[],
}

export interface SeatsToBook{
    Email : string,
    SeatPositions: SeatPosition[],
}