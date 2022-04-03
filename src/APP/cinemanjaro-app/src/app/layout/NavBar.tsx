import { Container, Dropdown, Icon, Menu } from "semantic-ui-react";

const NavBar = () => {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header >
                    <Icon name="film"/>
                    Cinemanjaro
                </Menu.Item>
                <Menu.Item name='On screen' />
                <Menu.Item name='Book a seat' />
                <Menu.Item name='About us' />
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