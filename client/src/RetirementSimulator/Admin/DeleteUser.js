import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { getToken } from "../TokenService.js";
import { adminUrl } from '../endpoints.js';


function DeleteUser() {
    const adminUrl = "http://localhost:5170/api/Admin/"

    const schema = yup.object().shape({
        name: yup.string().default(""),
        role: yup.string().default(""),
        email: yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: yup.string().default(""),
        password: yup.string().default(""),
        subscriptionPeriodDate: yup.date().default(() => new Date())
    });

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data) => {
        console.log(data);
        // axios.get("https://api.url.com", {headers: {'Content-Type': 'application/json'} })
        // , {headers: {'Content-Type': 'application/json'} }
        var config = {
            headers: { Authorization: `Bearer ${getToken()}` }
        };
        axios.delete(`${adminUrl}DeleteUser`, data, config)
            .then(response => {
                console.log(response.data);
            })
            .catch(error => {
                console.log(error);
                alert("נראה שקרתה תקלה. 🧐")
            });
    };

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
                <label>כתובת מייל:</label>
                <input {...register("email")} placeholder="email" type="email" ></input>
                <p style={{ "color": "red" }}>{errors.email?.message}</p>

                {/* <label>שם:</label>
                <input {...register("name")} type="text" />
                {/* <p style={{ "color": "red" }}>{errors.name?.message}</p> */}

                {/* <label>תפקיד:</label>
                <input {...register("role")} type="text" /> */}
                {/* <p style={{ "color": "red" }}>{errors.role?.message}</p> */}


                {/* <label>טלפון:</label>
                <input {...register("phoneNumber")} type="text" /> */}
                {/* <p style={{ "color": "red" }}>{errors.phoneNumber?.message}</p> */}

                {/* <label>סיסמה:</label>
                <input {...register("password")} type="password" /> */}
                {/* <p style={{ "color": "red" }}>{errors.password?.message}</p> */}

                {/* <label>תוקף מנוי:</label>
                <input {...register("subscriptionPeriodDate")} type="text" /> */}
                {/* <p style={{ "color": "red" }}>{errors.subscriptionPeriodDate?.message}</p> */}
                <button type="submit">מחק</button>
            </form>
        </>
    );
}
export default DeleteUser;