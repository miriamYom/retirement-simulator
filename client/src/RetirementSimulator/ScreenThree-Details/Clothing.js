import { useState } from "react";
// import { useLocation } from 'react-router-dom';
// import PreviousNext from "../PreviousNext";

export default function Clothing() {

    // const location = useLocation();
    // const data = location.state.data;

    const [isClothingForAudienceMembers, setIsClothingForAudienceMembers] = useState(false);
    const [isMonthlyClothingPayment, setIsMonthlyClothingPayment] = useState(false);
    const [isThreeLevel, setIsThreeLevel] = useState(false);
    const [isCurrentYear, setIsCurrentYear] = useState(false);
    const [monthOfClothingPayment, setMonthOfClothingPayment] = useState('January');

    const months =
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

    // const addDetails = () => {
    //     data.isClothingForAudienceMembers = isClothingForAudienceMembers;
    //     data.isMonthlyClothingPayment = isMonthlyClothingPayment;
    //     data.isThreeLevel = isThreeLevel;
    //     data.isCurrentYear = isCurrentYear;
    //     data.monthOfClothingPayment = monthOfClothingPayment;
    // };




    return (
        <>
            <label>זכאות העובד לביגוד</label> <br></br>
            <input type="radio" value={true} name="isClothingForAudienceMembers" onChange={(e) => setIsClothingForAudienceMembers(e.target.value)} /> ביגוד למקבלי קהל
            <input type="radio" value={false} name="isClothingForAudienceMembers" onChange={(e) => setIsClothingForAudienceMembers(e.target.value)} /> ביגוד לפועלים

            {isClothingForAudienceMembers === "true" ?
                (<>
                    <br></br> <label>אופן תשלום הביגוד</label> <br></br>
                    <input type="radio" value={true} name="isMonthlyClothingPayment" onChange={(e) => setIsMonthlyClothingPayment(e.target.value)} /> חודשי
                    <input type="radio" value={false} name="isMonthlyClothingPayment" onChange={(e) => setIsMonthlyClothingPayment(e.target.value)} /> שנתי

                    <br></br> <label>רמת הביגוד</label> <br></br>
                    <input type="radio" value={true} name="IsThreeLevel" onChange={(e) => setIsThreeLevel(e.target.value)} /> רמה 3
                    <input type="radio" value={false} name="IsThreeLevel" onChange={(e) => setIsThreeLevel(e.target.value)} /> רמה 4

                </>) : null}

            {isMonthlyClothingPayment === "true" ?
                (<>
                    <br></br> <label>חודש תשלום הביגוד</label> <br></br>
                    <select name="monthOfClothingPayment" onChange={(e) => setMonthOfClothingPayment(e.target.value)}>
                        {months}
                    </select>

                </>) : null}

            {isClothingForAudienceMembers === "true" ?
                (<>
                    <br></br> <label>השנה עבורה משולם הביגוד</label> <br></br>
                    <input type="radio" value={true} name="IsCurrentYear" onChange={(e) => setIsCurrentYear(e.target.value)}/> שנה קנדרית קודמת
                    <input type="radio" value={false} name="IsCurrentYear" onChange={(e) => setIsCurrentYear(e.target.value)}/> שנה נוכחית
                </>) : null}
                {/* {addDetails()} */}
                {/* {console.log(data)} */}
        </>
    )
}
