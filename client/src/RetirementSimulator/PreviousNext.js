import './style/PreviousNext.css';
import { useNavigate } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";

// the func get props who set witch page to go
function PreviousNext(props) {
    let user = useSelector((state) => state.userReducer);
    const navigate = useNavigate();

    return (

        <div className="group-289375">
            {props.next !== "GeneralData" & props.next !== "PensionType" ?
                (<button className="button1"
                    onClick={() => {
                        navigate(-1, { state: { data: props.data } });
                    }}
                >
                    הקודם</button>) : (null)}

            <button className="button2" onClick={() => {
                navigate(`/${props.next}`, { state: { data: props.data } });
            }} disabled={!props.enableNext} >
                {props.next === "Calculation" ? "חשב" : (
                    props.next === "PensionType" ?
                        "לסימולטור" :
                        "הבא")}
            </button>
          
            {
                user.role === "Admin" || user.role === "admin" ?
                    <button className='button3'
                        onClick={() => navigate("/Admin")}
                    >מנהל</button> : null
            }
-
        </div>
    );
}
export default PreviousNext;