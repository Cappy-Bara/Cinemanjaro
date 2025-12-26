import axios, { AxiosResponse } from "axios";
import { LoginData, RegisterData, Token } from "../models/Account";
import { AllMoviesResponse, Movie, MoviesResponse } from "../models/Movie";
import { UserTickets } from "../models/Ticket";
import { SeatsToBook, ShowDetails, ShowsResponse } from "../models/Show";

axios.defaults.baseURL = process.env.REACT_APP_API_BASE_URL;

const handleLogout = () => {
    if(axios.defaults.headers){
        axios.defaults.headers.common = {'Authorization': `Bearer EMPTY`};
    }
}

const handleLogin = (token : string) => {
    if(axios.defaults.headers){
        axios.defaults.headers.common = {'Authorization': `Bearer ${token}`};
    };
}

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

const Movies = {
    all: (page : number, pageSize : number) => requests.get<AllMoviesResponse>(`Movies?page=${page}&pageSize=${pageSize}`),
    onScreen: () => requests.get<MoviesResponse>(`Movies/on-screen`),
    details: (id: string) => requests.get<Movie>(`Movies/${id}`)
}

const Tickets = {
    AllUserTickets: () => requests.get<UserTickets>(`Tickets`),
}

const Account = {
    login: (data: LoginData) => requests.post<Token>(`Users/login`,data)
        .then(response => handleLogin(response.toString())),
    register: (data: RegisterData) => requests.post(`Users/register`,data),
    logout: () => handleLogout()
}


const agent = {
    Shows,
    Movies,
    Tickets,
    Account
}

export default agent;