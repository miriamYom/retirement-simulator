import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { getToken, setTokens, refreshAndUpdateTokens } from "../TokenService.js";
import { adminUrl } from '../endpoints.js';


function CreateUser() {
    const adminUrl = "http://localhost:5170/Admin/"

    const schema = yup.object().shape({
        name: yup.string().required(),
        role: yup.string().required(),
        email: yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: yup.string().required(),
        password: yup.string().required('Password is required').min(8, 'סיסמה חייבת להכיל 8 תוים')
            .matches(/[0-9]/, 'Password requires a number')
            .matches(/[a-z]/, 'Password requires a lowercase letter')
            .matches(/[A-Z]/, 'Password requires an uppercase letter')
            .matches(/[^\w]/, 'Password requires a symbol'),
        subscriptionPeriodDate: yup.date().required()
    });


    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });
    const createUser = async (data) => {
        var config = {
            headers: { Authorization: `Bearer ${getToken()}`}
        };
        await axios.post(`${adminUrl}CreateUser`, data, config)
            .then(response => console.log(response.data))
            .catch(error => {
                if (error.response && error.response.status === 401) {
                    refreshAndUpdateTokens()
                    createUser(data)
                } else {
                    alert("נראה שקרתה תקלה. 🧐");
                    console.log(error);
                }
            })
    };
    const onSubmit = (data) => {
        createUser(data)
        console.log("data: ", data);
        // var config = {
        //     headers: { Authorization: `Bearer ${getToken()}` }
        // };
        // axios.post(`${adminUrl}CreateUser`, data, config)
        //     .then(response => console.log(response.data))
        //     .then(alert("good"))
        //     .catch(error => {
        //         if (error.response && error.response.status === 401) {
        //             // Access token has expired, refresh it
        //             const refresh_token = refreshAndUpdateTokens()
        //             setTokens(refresh_token)
        //         } else {
        //             alert("נראה שקרתה תקלה. 🧐");
        //             console.log(error);
        //         }
        //     })
    };

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>

                <label>שם:</label>
                <input {...register("name")} type="text" />
                <p style={{ "color": "red" }}>{errors.name?.message}</p>

                <label>תפקיד:</label>
                <select {...register("role")} >
                    <option value="חשב.ת שכר">חשב.ת שכר</option>
                    <option value="מנהל.ת משאבי אנוש">מנהל.ת משאבי אנוש</option>
                    <option value="גזבר.ית">גזבר.ית</option>
                    <option value="מנכל">מנכ"ל</option>
                </select>
                {/* <input {...register("role")} type="text" /> */}
                <p style={{ "color": "red" }}>{errors.role?.message}</p>

                <label>כתובת מייל:</label>
                <input {...register("email")} placeholder="email" type="email" />
                <p style={{ "color": "red" }}>{errors.email?.message}</p>

                <label>טלפון:</label>
                <input {...register("phoneNumber")} type="text" />
                <p style={{ "color": "red" }}>{errors.phoneNumber?.message}</p>

                <label>סיסמה:</label>
                <input {...register("password")} type="password" />
                <p style={{ "color": "red" }}>{errors.password?.message}</p>

                <label>תוקף מנוי:</label>
                <input {...register("subscriptionPeriodDate")} type="date" />
                <p style={{ "color": "red" }}>{errors.subscriptionPeriodDate?.message}</p>

                <button type="submit">Submit</button>
            </form>
        </>
    );
};
export default CreateUser;