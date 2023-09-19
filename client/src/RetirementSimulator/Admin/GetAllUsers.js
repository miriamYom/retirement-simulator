import { AllInbox } from '@mui/icons-material';
import axios from 'axios';
import { useState } from 'react';
import { useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { getToken } from "../TokenService.js";
import { adminUrl } from '../endpoints.js';

export default function GetAllUsers() {

    // const allUsers = useRef();
    const [allUsers,setallUsers] = useState();
    const navigate = useNavigate();
    const adminUrl = "http://localhost:5170/Admin/"


    const [flag, setflag] = useState(false);
    function getAll() {
        setflag(true);
        var config = {
            headers: { Authorization: `Bearer ${getToken()}` }
        };
        axios.get(`${adminUrl}GetAll`, config)
            .then((response) => {
                setallUsers(response.data);
                console.log(allUsers);
                setflag(true);
                // navigate("/", { state: { data: response.data } });
            })
            .catch((error)=>console.error(error));
    }

    return (
        <center>
            <button disabled={flag} onClick={getAll}>קבל פרטי כל המנויים</button>
            <table  class="table table-bordered border-primary">
                <tr class="table-info">
                    <th>שם</th>
                    <th>תפקיד</th>
                    <th>כתובת מייל</th>
                    <th>סיסמה</th>
                    <th>טלפון</th>
                    <th >תוקף מנוי</th>
                </tr>
                {Array.isArray(allUsers) ? (
                   Object.keys(allUsers).map((key, index) => (
                        <tr key={index}>
                            <td> {allUsers[key].name}</td>
                            <td>{allUsers[key].role}</td>
                            <td> {allUsers[key].email}</td>
                            <td>{allUsers[key].password}</td>
                            <td>{allUsers[key].phoneNumber}</td>
                            <td> {allUsers[key].subscriptionPeriodDate.slice(0, 10)}</td>
                        </tr>
                    ))
                ) : (
                    <p>לא נמצאו משתמשים</p>
                )}
            </table>
        </center>
    );
}

