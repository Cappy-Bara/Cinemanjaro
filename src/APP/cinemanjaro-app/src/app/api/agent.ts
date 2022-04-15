import axios, { AxiosResponse } from "axios";
import { SeatsToBook, ShowDetails, ShowsResponse } from "../models/Show";

axios.defaults.baseURL = 'http://localhost:5295/api';

const responseBody = <T> (response : AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url,body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url,body).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Shows = {
    list: (date : string) => requests.get<ShowsResponse>(`/Shows/date/${date}`),
    details: (id: string) => requests.get<ShowDetails>(`/Shows/${id}`),
    bookSeats: (id:string, seats: SeatsToBook,) => requests.post<void>(`/Shows/${id}`,{...seats})
}

const agent = {
    Shows
}

export default agent;