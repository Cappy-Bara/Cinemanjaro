import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Container } from "semantic-ui-react";
import agent from "../../app/api/agent";
import { LoginData } from "../../app/models/Account";


const LoginScreen = () => {

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
        agent.Account.login(formData).then(r => {
        })
    };

    return (
        <>

        <Container>

            <h1>Login</h1>

            <form className="ui form">
                <div className="field">
                    <label>Email</label>
                    <input type="text" name="first-name" placeholder="Email" />
                </div>
                <div className="field">
                    <label>Password</label>
                    <input type="password" name="last-name" placeholder="Password" />
                </div>

                <button className="ui button" type="submit">Submit</button>
            </form>
        
            </Container>
        </>
    )
}




export default LoginScreen;