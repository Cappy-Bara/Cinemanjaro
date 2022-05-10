import {Link, NavLink } from "react-router-dom";
import { Container, Dropdown, Icon, Menu } from "semantic-ui-react";

const NavBar = () => {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header as={Link} to="/">
                    <Icon color="yellow" name="film"/>
                    Cinemanjaro
                </Menu.Item>
                <Menu.Item name='On screen' as={NavLink} to="/movies"/>
                <Menu.Item name='Book a seat' as={NavLink} to="/shows"/>
                <Menu.Item name='About us' as={NavLink} to="/aboutus"/>
                <Menu.Item position='right'>
                    <Dropdown pointing='top left' text='Account'>
                        <Dropdown.Menu >
                            <Dropdown.Item text='Register' icon='write' />
                            <Dropdown.Item text='Login' icon='lock open' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>)
}

export default NavBar;