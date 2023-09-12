//קומפוננטה מיותרת בעיקרון. חולקה ל3 קומפוננטות משנה
import { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from "yup";

function GeneralData() {

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
                    <input name="name" {...register('name')} placeholder="שם העובד"></input>
                    <br></br>
                    <input name="id" {...register('id')} placeholder="תעודת זהות"></input>
                    <h4>תאריך לידה</h4>
                    <input name="birthDate" {...register('birthDate')} type="date"></input>
                    <h4>תאריך תחילת עבודה</h4>
                    <input name="startWorkDate" {...register('startWorkDate')} type="date"></input>
                    <h4>תאריך פרישה צפוי</h4>
                    <input name="retirementDate" {...register('retirementDate')} type="date"></input>
                    <h4>סוג הפרישה</h4>
                    <select name="reason" {...register("reason")}
                        onChange={Reason}>
                        <option value="retirementAge">גיל פרישה</option>
                        <option value="resignation">התפטרות</option>
                        <option value="dismissal">פיטורין</option>
                        <option value="retirementForHealthReasons">סיבה רפואית</option>
                        <option value="death">מוות</option>
                    </select>

                    <br></br>
                    {reason === "dismissal" ?
                        (<>
                            <h4>חלף הודעה מוקדמת</h4>
                            <select name="advanceNotice" {...register("advanceNotice")}>
                                <option value="notEligible">לא זכאי</option>
                                <option value="month">חודש</option>
                                <option value="twoMonths">חודשיים</option>
                                <option value="treeMonths">שלושה חודשים</option>
                            </select>
                        </>) : null}
                    <h1>ביגוד</h1>
                    <h4>זכאות העובד לביגוד</h4>
                    <input type="radio" value="false" name="isClothingForAudienceMembers" {...register('isClothingForAudienceMembers')} onChange={clothingForAudienceMembers} /> ביגוד למקבלי קהל
                    <input type="radio" value="true" name="isClothingForAudienceMembers" {...register('isClothingForAudienceMembers')} onChange={clothingForAudienceMembers} /> ביגוד לפועלים

                    {isClothingForAudienceMembers === "true" ?
                        (<>
                            <br></br>
                            <h4>אופן תשלום הביגוד</h4>
                            <input type="radio" value="false" name="isMonthlyClothingPayment" {...register('isMonthlyClothingPayment')} onChange={monthlyClothingPayment} /> חודשי
                            <input type="radio" value="true" name="isMonthlyClothingPayment" {...register('isMonthlyClothingPayment')} onChange={monthlyClothingPayment} /> שנתי
                            <h4>רמת הביגוד</h4>
                            <input type="radio" value="false" name="IsThreeLevel" {...register('IsThreeLevel')} onChange={threeLevel} /> רמה 3
                            <input type="radio" value="true" name="IsThreeLevel" {...register('IsThreeLevel')} onChange={threeLevel} /> רמה 4
                        </>) : null}
                    {isMonthlyClothingPayment === "false" ?
                        (<>
                            <h4>חודש תשלום הביגוד</h4>
                            <select name="monthOfClothingPayment" {...register("monthOfClothingPayment")}>
                                {months}
                            </select>
                        </>) : null}

                    {isClothingForAudienceMembers === "true" ?
                        (<>
                            <h4>השנה עבורה משולם הביגוד</h4>
                            <input type="radio" value="true" name="IsCurrentYear" {...register('IsCurrentYear')} onChange={currentYear} /> שנה קנדרית קודמת
                            <input type="radio" value="false" name="IsCurrentYear" {...register('IsCurrentYear')} onChange={currentYear} /> שנה נוכחית
                        </>) : null}

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
export default GeneralData;