import axios from "axios";
import { userUrl } from "./endpoints";
export const getTokenObj = () => {
    var token = sessionStorage.getItem("token");
    var refreshToken = sessionStorage.getItem("refreshToken");
    let tokens = {
        "token" : token,
        "refreshToken" : refreshToken
    }
    return tokens;
}
export const getToken = () => {
    var tokens = sessionStorage.getItem("token");
    return tokens;
}

export const setTokens = (tokens) =>{
    sessionStorage.setItem("token", tokens.token);
    sessionStorage.setItem("refreshToken", tokens.refreshToken);
}

export const refreshAndUpdateTokens = async () => {
    const userUrl = "http://localhost:5170/RetirementSimulator/"
    const token =  getTokenObj();
    console.log("Token ",token);
    await axios.post(`${userUrl}refresh`, token)
            .then((response) => {
                if (response.status < 300) {
                    setTokens(response.data);
                }
                else {
                    console.log("the http request faild");
                }
            })
            .catch((error) => console.log(error));
}