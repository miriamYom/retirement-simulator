import { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from "yup";

function Recovery() {

const onSubmit = (data) => {
    console.log(data);
}

const schema = yup.object().shape({
    name: yup.string().required(),
    id: yup.string().required(),
    birthDate: yup.date(),//min, max...
    startWorkDate: yup.date(),
    retirementDate: yup.date().required(),
    // reason:  enum
    //isClothingForAudienceMembers: radio button
    // IsThreeLevel: radio
    // monthOfClothingPayment: enum
    // IsCurrentYear: radio
    //IsMonthlyRecoveryPayment: radio
    numberOfDaysOfRecoveryToBePaid: yup.number().integer().min(8).max(13).required(),
    //recoveryPaymentMonth: enum

});

const { register, handleSubmit, formState: {errors} } = useForm({
    resolver: yupResolver(schema),
});

    let months =
        <>
            <option value="January">ינואר</option>
            <option value="February">פברואר</option>
            <option value="March">מרץ</option>
            <option value="April">אפריל</option>
            <option value="May">מאי</option>
            <option value="June">יוני</option>
            <option value="July">יולי</option>
            <option value="August">אוגוסט</option>
            <option value="September">ספטמבר</option>
            <option value="October">אוקטובר</option>
            <option value="November">נובמבר</option>
            <option value="December">דצמבר</option>
        </>

    const [isDismissal, setIsDismissal] = useState(true);
    const [reason, setReason] = useState('retirementAge');
    const [isClothingForAudienceMembers, setIsClothingForAudienceMembers] = useState(false);
    const [isMonthlyClothingPayment, setIsMonthlyClothingPayment] = useState(false);
    const [isThreeLevel, setIsThreeLevel] = useState(false);
    const [isCurrentYear, setIsCurrentYear] = useState(false);
    const [isMonthlyRecoveryPayment, setIsMonthlyRecoveryPayment] = useState(false);

    const clothingForAudienceMembers = e => {
        setIsClothingForAudienceMembers(e.target.value);
    }

    const monthlyClothingPayment = e => {
        setIsMonthlyClothingPayment(e.target.value);
    }

    const threeLevel = e => {
        setIsThreeLevel(e.target.value);
    }

    const Reason = e => {
        setReason(e.target.value);
    }

    const currentYear = e => {
        setIsCurrentYear(e.target.value);
    }

    const monthlyRecoveryPayment = e => {
        setIsMonthlyRecoveryPayment(e.target.value);
    }

    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
            <br></br><br></br><br></br><br></br><br></br><br></br><br></br>
                <center>

                    <h1>הבראה</h1>
                    <h4>אופן תשלום ההבראה</h4>
                    <input type="radio" value="true" name="IsMonthlyRecoveryPayment" {...register('IsMonthlyRecoveryPayment')} onChange={monthlyRecoveryPayment} /> תשלום שנתי
                    <input type="radio" value="false" name="IsMonthlyRecoveryPayment" {...register('IsMonthlyRecoveryPayment')} onChange={monthlyRecoveryPayment} /> תשלום חודשי
                    {console.log("תשלום חודשי ", isMonthlyRecoveryPayment)}

                    <h4>מספר ימי הבראה לתשלום</h4>
                    <select name="numberOfDaysOfRecoveryToBePaid" {...register("numberOfDaysOfRecoveryToBePaid")}>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                    </select>

                    {isMonthlyRecoveryPayment === "false" ?
                        (<>
                            <h4>חודש תשלום ההבראה</h4>
                            <select name="recoveryPaymentMonth" {...register("recoveryPaymentMonth")}>
                                {months}
                            </select>
                        </>) : null}
                </center>
                <input type="submit"></input>
            </form>
           
        </>
    )
}
export default Recovery;