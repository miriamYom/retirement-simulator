import './style/Card.css';
import './style/Table.css';

import Sequence from "./Sequence";
import PreviousNext from "./PreviousNext";
import PartialityTable from './ScreenFour-PartTimeJob/PartialityTable';
import { useLocation } from 'react-router-dom';

function PartTimeJob() {
    var dateobj = new Date();

    const location = useLocation();
    let employeeDetails = location.state.data;

    let enableNext = true;

    return (
        <>
            <Sequence page="4"></Sequence>

            <div class="card bg-light mb-3">
                <div class="card-header">חלקיות משרה</div>
                <div class="card-body tbl">
                    <PartialityTable></PartialityTable>
                    <div>
                        <p className='p1-pg4'>חלקיות משרת העובד בשנת הפרישה - {dateobj.getFullYear()}: </p>
                        <label className='p2-pg4'>על המשתמש להזין אחוז , בין 0% ל- 100%</label>
                        <input className='input-pg4'></input>
                        <p className='p1-pg4'>חלקיות משרת העובד בשנת הפרישה - {dateobj.getFullYear()-1}: </p>
                        <label className='p2-pg4'>על המשתמש להזין אחוז , בין 0% ל- 100%</label>
                        <input className='input-pg4'></input>
                    </div>
                </div>
            </div>

            <PreviousNext next="Calculation" enableNext={enableNext}></PreviousNext>
        </>
    );
}
export default PartTimeJob;