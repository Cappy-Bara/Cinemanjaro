import { Show } from "../../app/models/Show"
import {Message} from "semantic-ui-react"
import ShowListElement from "./ShowListElement";

interface props {
    shows: Show[]
}

const ShowList = ({ shows }: props) => {

    return (
        <>
            {
                shows ?
                    (
                    shows.map(show =>
                        <ShowListElement key={show.id} show={show} />
                    )
                    )
                    :
                    <Message
                        icon='ticket'
                        header="Unfortunately, we don't have any seanses for chosen day."
                        content='Please select different day from our callendar.'
                  />
            }
        </>
    )

}

export default ShowList;