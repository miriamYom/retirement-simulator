import "./style/Card.css";
import "./style/PensionType.css";

import { useState, useEffect } from "react";
import PreviousNext from "./PreviousNext";
import Sequence from "./Sequence";
//very good design:
//https://mui.com/joy-ui/react-radio-button/#segmented-controls
const pension = {
    BudgetPension: "BudgetPension",
    AccrualPension: "AccrualPension",
    BudgetPensionForSenior: "BPSForSenior"
}

function PensionType() {
    const [justify, setJustify] = useState('flex-start');

    useEffect(() => {
        employeeDetails.PensionType !== null ? setEnableNext(true) : setEnableNext(false);
    }, 0);

    const [isBudgetPension, setIsBudget] = useState(false);
    const employeeDetails = {};
    const [enableNext, setEnableNext] = useState(false);

    return (
        <>
            <Sequence page="1"></Sequence>
            <div class="card bg-light mb-3">
                <div class="card-header">סוג פנסיה</div>
                <div class="card-body">
                    <p>איזה סוג פנסיה תרצה לחשב?</p>

                    <button className="btn btn-outline-primary" onClick={() => {
                        employeeDetails.PensionType = pension.BudgetPension;
                        setIsBudget(true);
                    }}> פנסיה תקציבית </button>

                    <button name="accrualBtn" className="btn btn-outline-primary"
                        onClick={() => {
                            employeeDetails.PensionType = pension.AccrualPension;
                            setEnableNext(true);
                        }}> פנסיה צוברת</button>
                    <br></br>
                    <br></br>
                    {isBudgetPension === true ? (
                        <button className="btn btn-outline-primary"
                            onClick={() => { setEnableNext(true); }}>הסכם קיבוצי</button>
                    ) : (null)}
                    {isBudgetPension === true ? (
                        <button className="btn btn-outline-primary" onClick={() => {
                            employeeDetails.PensionType = pension.BudgetPensionForSenior;
                            setEnableNext(true);
                        }}> הסכם קיבוצי ושכר בכירים</button>
                    ) : (null)}
                </div>
            </div >
            <PreviousNext next="GeneralData" enableNext={enableNext}></PreviousNext>
        </>
    )
}
export default PensionType;