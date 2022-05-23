import { useEffect, useState } from "react";
import {useParams } from "react-router-dom";
import agent from "../../../app/api/agent";
import { Seat } from "../../../app/models/Seat";
import { ShowDetails } from "../../../app/models/Show";
import BookSeatsFirstStep from "../BookSeatsFirstStep/BookSeatsFirstStep";
import BookSeatsSecondStep from "../BookSeatsSecondStep/BookSeatsSecondStep";
import './styles.css'

interface props{
    userEmail:string;
}

const BookSeatsDashboard = ({userEmail} : props) => {

    let c : ShowDetails = {
        id: "",
        date: new Date(),
        title: "",
        seats: [],
        iconURL: "",
        movieId: "",
        lengthMins: 0,
        genres: []
    }

    const [showDetails, setShowDetails] = useState<ShowDetails>(c)
    const [chosenSeats, setChosenSeats] = useState<Seat[]>([])
    const [isFirstStep, setIsFirstStep] = useState<Boolean>(true);

    const { id } = useParams<{ id: string }>();

    const fetchShowDetails = () => {
        agent.Shows.details(id ?? "").then(fetchedShow =>
            setShowDetails(fetchedShow))
    }

    useEffect(() => {
        fetchShowDetails();
    }, [])


    return (
        <>
        {
            isFirstStep ? 
                <BookSeatsFirstStep setIsFirstStep={setIsFirstStep} setSeats={setChosenSeats} chosenSeats={chosenSeats} showDetails={showDetails}/>            
            :
                <BookSeatsSecondStep 
                    userEmail={userEmail}
                    showDetails={showDetails} 
                    selectedSeats={chosenSeats}
                    setIsFirstStep={setIsFirstStep}
                    />
        }
        </>
    )
}

export default BookSeatsDashboard;