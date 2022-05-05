import { Link } from "react-router-dom"
import { Container, Image, Header, Segment, Icon, Button, Divider } from "semantic-ui-react"

const HomePage = () => {

    return (
        <Container textAlign="center">
            <Header
                as='h1'
                content='Cinemanjaro'
                inverted
                style={{
                    fontSize: '4em',
                    fontWeight: 'normal',
                    marginBottom: 0,
                    color: 'black',
                    marginTop: '4em',
                }}
            />
            <Header
                as='h2'
                content='All the latest movies at your fingertip'
                inverted
                style={{
                    color: 'black',
                    fontSize: '1.7em',
                    fontWeight: 'normal',
                    marginTop: '1.5em',
                }}
            />

            <Button as={Link} to='/shows' color="yellow" size='huge' style={{marginTop: '1.5em'}}>
                <Icon name="ticket" />
                Book a ticket!
            </Button>

        </Container>)
}


export default HomePage