import { useState } from "react";
import { addDetail } from "../../redux/actions/employeeAction";
import { useLocation } from 'react-router-dom';
import { useSelector, useDispatch } from "react-redux";

// לסדר שלא יהיה אפשר לעבור לשלב הבא בלי להזין את כל הנתונים
// לעצב
export default function PersonalData() {

    const dispatch = useDispatch();
    // let emp = useSelector((state) => state.employeeReducer);

    const location = useLocation();
    const data = location.state.data;

    const [name, setName] = useState('');
    const [id, setId] = useState('');
    const [birthDate, setBirthDate] = useState();
    const [startWorkDate, setStartWorkDate] = useState();
    const [retirementDate, setRetirementDate] = useState();
    const [retirementReason, setRetirementReason] = useState('retirementAge');
    const [advanceNotice, setAdvanceNotice] = useState('notEligible'); //חלף הודעה מוקדמת

    // const addDetails = () => {
    //     data.name = name;
    //     data.id = id;
    //     data.birthDate = birthDate;
    //     data.startWorkDate = startWorkDate;
    //     data.retirementDate = retirementDate;
    //     data.retirementReason = retirementReason;
    //     data.advanceNotice = advanceNotice;
    // };

    return (
        <div className="wrepper">
            {console.log("Im in personal data and this is my obj: \n", data)}
            <div className="grid-item">
                <p className="item">שם העובד</p>
                <input className="item"
                    name="name"
                    onChange={(e) => setName(e.target.value)}
                ></input>
            </div>
            <div className="grid-item">
                <p className="item">תעודת זהות</p>
                <input className="item"
                    name="id"
                    onChange={(e) => {
                        e.preventDefault();
                        dispatch(addDetail("id", e.target.value));
                    }}
                ></input>
            </div>
            <div className="grid-item">
                <p className="item">תאריך לידה</p>
                <input className="item"
                    name="birthDate"
                    type="date"
                    onChange={(e) => setBirthDate(e.target.value)}
                ></input>
            </div>
            <div className="grid-item">
                <p className="item">תאריך תחילת עבודה</p>
                <input className="item"
                    name="startWorkDate"
                    type="date"
                    onChange={(e) => setStartWorkDate(e.target.value)}
                ></input>
            </div>
            <div className="grid-item">
                < p className="item">תאריך פרישה צפוי</ p>
                <input className="item"
                    name="retirementDate"
                    type="date"
                    onChange={(e) => setRetirementDate(e.target.value)}
                ></input>
            </div>
            <div className="grid-item">
                < p className="grid-item">סוג הפרישה</ p>
                <select className="item" name="reason" value={retirementReason} onChange={(e) => setRetirementReason(e.target.value)} /*{...register("reason")} onChange={Reason}*/ >
                    <option value="retirementAge">גיל פרישה</option>
                    <option value="resignation">התפטרות</option>
                    <option value="dismissal">פיטורין</option>
                    <option value="retirementForHealthReasons">סיבה רפואית</option>
                    <option value="death">מוות</option>
                </select>
            </div>

            {retirementReason === "dismissal" ?
                (<>
                    <div className="grid-item">
                        < p className="grid-item">חלף הודעה מוקדמת</ p>
                        <select className="item" name="advanceNotice" value={advanceNotice} onChange={(e) => setAdvanceNotice(e.target.value)}/*{...register("advanceNotice")}*/>
                            <option value="notEligible">לא זכאי</option>
                            <option value="month">חודש</option>
                            <option value="twoMonths">חודשיים</option>
                            <option value="treeMonths">שלושה חודשים</option>
                        </select>
                    </div>
                </>)
                : null
            }

        </div >
    );
}