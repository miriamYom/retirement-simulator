import { useState } from "react";

function Sickness(){

    const [isLastSalary, setIsLastSalary] = useState();

    const lastSalary = e => {
        setIsLastSalary(e.target.value);
    }
    return(
        <>
        <h4>מחלה</h4>
        <p>יש להזין יתרה בימים ולא בשעות</p> {/** צריך להיות בתוך אייקון של סימן שאלה */}
        <p>יתרת ימי מחלה בפרישה</p>
        <input></input>
        <p>אופן צבירת המחלה</p>
        <input type="radio" name="accumulation">צבירה מלאה</input>
        <input type="radio" name="accumulation">צבירה לפי חלקיות</input>
        {/* אם העובד מועסק בהסכם קיבוצי ושכר בכירים */}
        {/* מעבר להסכם בכירים- עוד 2 שאלות (לא מעוצב בפיגמה) */}
        <p>האם בחוזה העסקה נקבע כי פדיון ימי המחלה ישולם לפי משכורת אחרונה?</p>
        <p>יש לבדוק בחוזה העסקתו של העובד</p> {/** צריך להיות בתוך אייקון של סימן שאלה */}
        <input type="radio" name="lastSalary" value="true" onChange={lastSalary}>כן</input>
        <input type="radio" name="lastSalary" value="false" onChange={lastSalary}>לא</input>
        
        </>
    )
};
export default Sickness;