import "./style/Card.css";
import "./style/PensionType.css";
import { useSelector, useDispatch } from "react-redux";
import { useState, useEffect } from "react";
import PreviousNext from "./PreviousNext";
import Sequence from "./Sequence";
import { addDetail } from "../redux/actions/employeeAction";
//very good design:
//https://mui.com/joy-ui/react-radio-button/#segmented-controls
function PensionType() {
    const [justify, setJustify] = useState('flex-start');
    const dispatch = useDispatch();
    const employeeDetails = useSelector((state) => state.employeeReducer);
    useEffect(() => {
        employeeDetails.PensionType !== null ? setEnableNext(true) : setEnableNext(false);
    }, 0);

    const [isBudgetPension, setIsBudget] = useState(false);
    const [enableNext, setEnableNext] = useState(false);

    return (
        <>
            <Sequence page="1"></Sequence>
            <div class="card bg-light mb-3">
                <div class="card-header">סוג פנסיה</div>
                <div class="card-body">
                    <p>איזה סוג פנסיה תרצה לחשב?</p>
                    <button className="btn btn-outline-primary" onClick={() => {
                        dispatch(addDetail("pensionType", "BudgetPension"))
                        setIsBudget(true);
                    }}> פנסיה תקציבית </button>
                    <button name="accrualBtn" className="btn btn-outline-primary"
                        onClick={() => {
                            dispatch(addDetail("pensionType", "AccrualPension"))
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
                            dispatch(addDetail("pensionType", "BudgetPensionForSenior"))
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