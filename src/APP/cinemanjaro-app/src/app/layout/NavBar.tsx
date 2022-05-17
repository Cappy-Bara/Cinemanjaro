import { Link, NavLink } from "react-router-dom";
import { Container, Dropdown, Icon, Menu } from "semantic-ui-react";

interface props {
    loggedUser: string
}

const NavBar = ({ loggedUser }: props) => {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header as={Link} to="/">
                    <Icon color="yellow" name="film" />
                    Cinemanjaro
                </Menu.Item>
                <Menu.Item name='On screen' as={NavLink} to="/movies" />
                <Menu.Item name='Book a seat' as={NavLink} to="/shows" />
                <Menu.Item name='About us' as={NavLink} to="/aboutus" />
                <Menu.Item position='right'>
                    <Dropdown pointing='top left' text={loggedUser ? loggedUser : "Account"}>
                        <Dropdown.Menu >
                            {
                                loggedUser ?
                                    <>
                                        <Dropdown.Item text='My tickets' icon='write' as={NavLink} to="/tickets" />
                                        <Dropdown.Item text='Logout' icon='lock open' as={NavLink} to="/" />
                                    </>
                                    :
                                    <>
                                        <Dropdown.Item text='Register' icon='write' as={NavLink} to="/register" />
                                        <Dropdown.Item text='Login' icon='lock open' as={NavLink} to="/login" />
                                    </>}
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>)
}

export default NavBar;