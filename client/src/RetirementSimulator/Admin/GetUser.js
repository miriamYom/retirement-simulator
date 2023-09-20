import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { useState } from 'react';
import { getToken } from "../TokenService.js";
import { adminUrl } from '../endpoints.js';


function GetUser() {
    const adminUrl = "http://localhost:5170/api/Admin/"

    let [user, setUser] = useState({});

    const schema = yup.object().shape({
        name: yup.string().default(""),
        role: yup.string().default(""),
        email: yup.string().email('כתובת מייל שגויה').required('חובה להזין כתובת מייל'),
        phoneNumber: yup.string().default(""),
        password: yup.string().default(""),
        subscriptionPeriodDate: yup.date().default(() => new Date()) //מה לגבי זה?
    });

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data) => {
        console.log(user);
        var config = {
            headers: { Authorization: `Bearer ${getToken()}` }
        };
        axios.post(`${adminUrl}GetDetails`, data ,config)
            .then(response => {
                setUser(response.data);
                console.log(user);
                if(user === ""){
                    {document.getElementById('user-not-found').hidden = false}
                }
            })
            .then(console.log("user", user))
            .catch(error => {console.log(error);
                alert("נראה שקרתה תקלה. 🧐")});
    };

    return (
        <>
            {Object.keys(user).length !== 0 ?
                <>
                    <p>שם:  {user.name}</p>
                    <p>סיסמא:  {user.password}</p>
                    <p>טלפון:  {user.phoneNumber}</p>
                    <p>תפקיד:  {user.role}</p>
                    <p>כתובת מייל:  {user.email}</p>
                </> :
                <form onSubmit={handleSubmit(onSubmit)}>
                    <label>כתובת מייל:</label>
                    <input {...register("email")} placeholder="email" type="email" ></input>
                    <p style={{ "color": "red" }}>{errors.email?.message}</p>
                    <p style={{ "color": "red" }} id='user-not-found' hidden='true'>לא נמצא משתמש עם כתובת מייל זו</p>
                    <button type="submit">הצג פרטים</button>
                </form>
            }
            
        </>
    );
}
export default GetUser;