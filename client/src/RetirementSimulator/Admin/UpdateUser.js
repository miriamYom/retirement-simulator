import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';

function UpdateUser() {


    const schema = yup.object().shape({
        name: yup.string().default(""),
        role: yup.string().default(""),
        email: yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: yup.string().default(""),
        password: yup.string().default(""),
        // .min(8, 'סיסמה חייבת להכיל 8 תוים')
        //     .matches(/[0-9]/, 'Password requires a number')
        //     .matches(/[a-z]/, 'Password requires a lowercase letter')
        //     .matches(/[A-Z]/, 'Password requires an uppercase letter')
        //     .matches(/[^\w]/, 'Password requires a symbol'),
        subscriptionPeriodDate: yup.date().default(() => new Date())
    });

    // function validateForm() {
    //     //change this
    //     return true;
    // };

    // function handleSubmit(event) {
    //     event.preventDefault();
    //     // createUser();
    // };

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data) => {
        console.log("data: ", data);
        let data2 = data;
        data.email = "";
        data2.phoneNumber = "";
        data2.role = "";
        data2.password = "";
        axios.post('http://localhost:5170/RentiermentSimulator/UpdateUser', [data2, data])
            .then(response => console.log(response.data))
            .then(alert("good"))
            // .catch(error => console.log(error));
            .catch(error => alert("נראה שקרתה תקלה. 🧐"));
    };

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
                <label> כתובת מייל של העובד הרצוי:</label>
                <input {...register("email")} placeholder="email" type="email" />
                <p style={{ "color": "red" }}>{errors.email?.message}</p>

                <p> הזן.י את הפרט שברצונך לעדכן:</p>

                <label>שם:</label>
                <input {...register("name")} type="text" />
                {/* <p style={{ "color": "red" }}>{errors.name?.message}</p> */}
                <br></br>

                <label>תפקיד:</label>
                <select {...register("role")} >
                    <option value="חשב.ת שכר">חשב.ת שכר</option>
                    <option value="מנהל.ת משאבי אנוש">מנהל.ת משאבי אנוש</option>
                    <option value="גזבר.ית">גזבר.ית</option>
                    <option value="מנכל">מנכ"ל</option>
                </select>
                {/* <input {...register("role")} type="text" /> */}
                {/* <p style={{ "color": "red" }}>{errors.role?.message}</p> */}
                <br></br>

                <label>טלפון:</label>
                <input {...register("phoneNumber")} type="text" />
                {/* <p style={{ "color": "red" }}>{errors.phoneNumber?.message}</p> */}
                <br></br>

                <label>סיסמה:</label>
                <input {...register("password")} type="password" />
                {/* <p style={{ "color": "red" }}>{errors.password?.message}</p> */}
                <br></br>

                <label>תוקף מנוי:</label>
                <input {...register("subscriptionPeriodDate")} type="date" />
                {/* <p style={{ "color": "red" }}>{errors.subscriptionPeriodDate?.message}</p> */}
                <br></br>

                <button type="submit">עדכן</button>
            </form>
        </>
    );

}
export default UpdateUser;