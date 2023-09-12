import "../style/Table.css";

import { CiCircleRemove } from 'react-icons/ci';

function TableRows({ rowsData, deleteTableRows, handleChange }) {

    return (
        rowsData.map((data, index) => {
            const { startDate, endDate, sum, partiality } = data;
            return (
                <tr key={index} className="table-row">
                    <td><input type="date" value={startDate} onChange={(evnt) => (handleChange(index, evnt))} name="startDate" className="form-control" /></td>
                    <td><input type="date" value={endDate} onChange={(evnt) => (handleChange(index, evnt))} name="endDate" className="form-control" /> </td>
                    <td><input type="text" value={sum} onChange={(evnt) => (handleChange(index, evnt))} name="sum" className="form-control" /> </td>
                    <td><input type="text" value={partiality} onChange={(evnt) => (handleChange(index, evnt))} name="partiality" className="form-control" /> </td>
                    {/* <td><button className="remove-row" onClick={() => (deleteTableRows(index))}><CiCircleRemove/></button></td> */}
                </tr> 
            )
        })
    );
}
export default TableRows;

