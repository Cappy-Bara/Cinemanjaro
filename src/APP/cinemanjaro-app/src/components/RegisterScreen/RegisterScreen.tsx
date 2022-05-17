import { useState } from "react";
import './styles.css';
import { useNavigate } from "react-router-dom";
import { Button, Container, Form, Grid, Header } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { RegisterData } from "../../app/models/Account";


const LoginScreen = () => {

    const navigate = useNavigate();

    const defaultValue: RegisterData = {
        email: "",
        password: ""
    };

    const [formData, updateFormData] = useState<RegisterData>(defaultValue);

    const handleChange = (e: any) => {
        const fieldName = e.target.name;
        let value = e.target.value.trim();
        updateFormData({
            ...formData,
            [fieldName]: value
        });
    };

    const handleSubmit = () => {
        console.log(formData);
        agent.Account.register(formData).then(r => {
            navigate("/register-succeeded");
        })
    };

    const goToLogin = () => {
        navigate("/login");
    }

    return (
        <>
            <Header as='h1' dividing textAlign="center">
                Register
            </Header>
            <Grid>
                <Grid.Row columns={3}>
                    <Grid.Column>
                    </Grid.Column>
                    <Grid.Column>
                        <Container style={{
                            marginTop: '4em'
                        }}>
                            <Form>
                                <Header as='h3' textAlign="center">
                                    Enter your register data
                                </Header>
                                <Form.Field>
                                    <label>Email</label>
                                    <input inputMode="email" name="email" placeholder='Email' onChange={handleChange} />
                                </Form.Field>
                                <Form.Field>
                                    <label>Password</label>
                                    <input type="password" name="password" placeholder='Password' onChange={handleChange} />
                                </Form.Field>
                                <Button primary floated="right" onClick={handleSubmit}>Register</Button>
                                <span>Already have an account? </span><span className="register" onClick={goToLogin}>Log in!</span>
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