import { Seat, SeatPosition } from "./Seat";

export interface Show{
    id : string,
    date : Date,
    title : string,
    iconURL : string,
    movieId : string,
    lengthMins : number,
    genres : string[],
}

export interface ShowsResponse{
    shows:Show[]
}

export interface ShowDetails{
    id : string,
    date : Date,
    title : string,
    iconURL : string,
    movieId : string,
    lengthMins : number,
    genres : string[],
    seats : Seat[],
}

export interface SeatsToBook{
    email : string,
    seatPositions: SeatPosition[],
}