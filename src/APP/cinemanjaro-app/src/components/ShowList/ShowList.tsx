import { Show } from "../../app/models/Show"
import ShowListElement from "./ShowListElement";

interface props{
    shows : Show[]
}

const ShowList = ({shows}:props) =>{

    return(
        <>
        {
        shows.map(show => 
            <ShowListElement key={show.Id} show={show} />
            )
        }
        </>
    )
    
}

export default ShowList;