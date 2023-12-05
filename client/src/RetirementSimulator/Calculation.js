import { useEffect, useRef, useState } from "react";
import axios from 'axios';
import { useSelector, useDispatch } from "react-redux";
import { removePensionType } from "../redux/actions/employeeAction";
import { getToken } from "./TokenService.js";
import { userUrl } from "./endpoints";
function Calculation() {
    const dispatch = useDispatch();
    let [result, setResult] = useState({});
    let employeeDetails = useSelector((state) => state.employeeReducer);
    const userUrl = "http://localhost:5170/user/"

    useEffect(() => {
        // dispatch(removePensionType());
        console.log(employeeDetails.pensionType);
        console.log(employeeDetails);
        var config = {
            headers: { Authorization: `Bearer ${getToken()}` }
        };
        axios.post(`${userUrl}GetPensionCalculates?pensionType=${employeeDetails.pensionType}`,
            employeeDetails, config)
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
