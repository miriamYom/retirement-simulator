import { useState } from "react"

function Report(){
    const [fixedSalary, setFixedSalary] = useState("");


    return(
        <>
        <h1>משכורת קובעת</h1>
        <input onChange={(e) => setFixedSalary(e.target.value)}></input>
        </>
    )
}
