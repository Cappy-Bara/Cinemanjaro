import { useNavigate } from "react-router-dom";
import { Button, Header, Icon, Segment } from "semantic-ui-react"

const ThankYouPage = () => {

    const navigate = useNavigate();

    return (
        <>
            <Segment textAlign="center" padded='very'>
                <Header as='h1'> Success!</Header>
                <Icon name="check circle outline" size="massive" color="green"></Icon>
                <Header as='h3'>Your tickets for the show has been sent to your email.</Header>
                <Button
                    primary
                    onClick={() => navigate("/")}
                    size="massive" >
                    Continue to homepage
                </Button>
                <Header as='h3'>Happy Watching!</Header>
            </Segment>
        </>)
}

export default ThankYouPage