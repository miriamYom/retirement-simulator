import "../style/Table.css";

import { useState, useEffect } from "react";
import TableRows from "./TableRows";

export default function PartialityTable() {

    useEffect(() => {
        addTableRows();
    },0);
    const [rowsData, setRowsData] = useState([]);

    const addTableRows = () => {

        const rowsInput = {
            startSate: '',
            endDate: '',
            sum: '',
            partiality: ''
        }
        setRowsData([...rowsData, rowsInput])
    }

    const deleteTableRows = (index) => {
        const rows = [...rowsData];
        rows.splice(index, 1);
        setRowsData(rows);
    }

    const handleChange = (index, evnt) => {
        const { name, value } = evnt.target;
        const rowsInput = [...rowsData];
        rowsInput[index][name] = value;
        setRowsData(rowsInput);
    }

    return (
        <>
            <div className="container">
                <div >
                    <table className="table">
                        <thead className="table-head">
                            <tr>
                                <th>תאריך תחילה </th>
                                <th>תאריך סיום</th>
                                <th>סה’’כ תקופת עבודה</th>
                                <th>חלקיות משרה</th>
                                {/* <th></th> */}
                            </tr>
                        </thead>
                        <tbody>
                            <TableRows rowsData={rowsData} deleteTableRows={deleteTableRows} handleChange={handleChange} />
                        </tbody>
                    </table>
                </div>
                <button className="add-row" onClick={addTableRows}>+</button>
            </div>
        </>
    );
}

