export interface Seat {
    row : Number,
    number : Number,
    status : SeatStatus,
}

export interface SeatPosition{
    row : Number,
    number : Number,
}


export enum SeatStatus{
    Free,
    Occupied
}