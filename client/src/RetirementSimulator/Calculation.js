import { useEffect, useRef, useState } from "react";
import axios from 'axios';
import { useSelector, useDispatch } from "react-redux";
import { removePensionType } from "../redux/actions/employeeAction";

function Calculation() {
    const dispatch = useDispatch();

    let [result, setResult] = useState({});
    let employeeDetails = useSelector((state) => state.employeeReducer);
    let [pensionType, setpensionType] = useState("BudgetPension");

    useEffect(() => {
        dispatch(removePensionType());
        console.log(pensionType);
        console.log(employeeDetails);
        axios.post(`http://localhost:5170/RentiermentSimulator/GetPensionCalculates?pensionType=${pensionType}`,
            employeeDetails)
            .then(response => setResult((response.data)))
            .catch(error => console.error('There was an error!\n', error))
            .catch(setResult({ "error": "someErrorIsHandle" }))
    }, []);

    return (
        <center>
            <table class="table table-bordered border-primary">
                <thead class="table-info">
                    <tr>
                        <th>תוצאה:</th>
                        <th>חישוב:</th>
                    </tr>
                </thead>
                {Object.keys(result).map((key, i) => (
                    <tr>
                        <td>{result[key]}</td>
                        <td>{key}</td>
                    </tr>
                ))}
            </table>
        </center>
    );
}
export default Calculation;
