export interface Seat {
    Row : Number,
    Number : Number,
    Status : SeatStatus,
}

export interface SeatPosition{
    Row : Number,
    Number : Number,
}


export enum SeatStatus{
    Free,
    Occupied
}