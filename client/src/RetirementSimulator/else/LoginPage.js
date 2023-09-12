import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function LoginPage() {
    const navigate = useNavigate();

    const [email, setEmail] = useState("");

    const [password, setPassword] = useState("");

    function validateForm() {
        return email.length > 0 && password.length > 0;
    }

    function handleSubmit(event) {
        event.preventDefault();
    }
    

//------------------------------------------------------------------
// let newfiles = this.state.newfiles;
    
// let formData = new FormData();

// // Adding files to the formdata
// formData.append("image", newfiles);
// formData.append("name", "Name");

// axios({

//   // Endpoint to send files
//   url: "http://localhost:8080/files",
//   method: "POST",
//   headers: {

//     // Add any auth token here
//     authorization: "your token comes here",
//   }, 

//   // Attaching the form data
//   data: formData,
// })

//   // Handle the response from backend here
//   .then((res) => { })

//   // Catch errors if any
//   .catch((err) => { });
//------------------------------------------------------------------


    function Login(){
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: `"${password}"`
        };
        fetch(`https://localhost:7049/RentiermentSimulator/Login?email=${email}`, requestOptions)
            .then(response => response.json())
            .then(data => console.log(data))
            .then(navigate('/ScreenOne'))
            .catch(error => {
                alert({ errorMessage: error.toString() });
                console.error('There was an error!\n', error);
            });
    }

    return (
        <center>
            <form onSubmit={handleSubmit}>
                <form size="lg" controlId="email">
                    <p>Email</p>
                    <input
                        autoFocus
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </form>
                <form size="lg" controlId="password">
                    <p>Password</p>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </form>
                <button block size="lg" type="submit" disabled={!validateForm()} onClick={Login}>
                    Login
                </button>
                
            </form>
        </center>
    );
}
export default LoginPage;