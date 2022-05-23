import { useState } from "react";
import './styles.css';
import { useNavigate } from "react-router-dom";
import { Button, Container, Form, Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { LoginData } from "../../app/models/Account";

interface props {
    setLoggedUser: React.Dispatch<React.SetStateAction<string>>
}


const LoginScreen = ({ setLoggedUser }: props) => {

    const navigate = useNavigate();

    const defaultValue: LoginData = {
        email: "",
        password: ""
    };

    const [formData, updateFormData] = useState<LoginData>(defaultValue);

    const handleChange = (e: any) => {
        const fieldName = e.target.name;
        let value = e.target.value.trim();
        updateFormData({
            ...formData,
            [fieldName]: value
        });
    };

    const handleSubmit = () => {
        agent.Account.login(formData).then(() => {
            setLoggedUser(formData.email)
            navigate("/");
        })
    };

    const goToRegister = () => {
        navigate("/register");
    }

    return (
        <>
            <Header as='h1' dividing textAlign="center">
                Login
            </Header>
            <Grid>
                <Grid.Row columns={3}>
                    <Grid.Column>
                    </Grid.Column>
                    <Grid.Column>
                        <Container style={{
                            marginTop: '4em'
                        }}>
                            <Form onSubmit={handleSubmit}>
                                <Header as='h3' textAlign="center">
                                    Enter your login data
                                </Header>
                                <Form.Field>
                                    <label>Email</label>
                                    <input
                                        inputMode="email"
                                        name="email"
                                        placeholder='Email'
                                        onChange={handleChange}
                                        type='email'
                                    />
                                </Form.Field>
                                <Form.Field>
                                    <label>Password</label>
                                    <input type="password" name="password" placeholder='Password' onChange={handleChange} />
                                </Form.Field>
                                <Button primary floated="right" type="submit">Login</Button>
                                <span>Don't have an account yet? </span><span className="register" onClick={goToRegister}>Register now!</span>
                            </Form>
                        </Container>
                    </Grid.Column>
                    <Grid.Column>
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </>
    )
}




export default LoginScreen;