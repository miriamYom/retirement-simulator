import "./style/Sequence.css";
import { VscCheck } from "react-icons/vsc";

function Sequence(props) {
    let page = parseInt(props.page);

    return (
        <div className="sequence">

            <p className="top-title">חישוב זכויות פרישה</p>
            <ellipse className={page < 2 ? (page === 1 ? "ellipse e-current" : "ellipse e-before") : "ellipse e-after"}>
                {page > 1 ? <VscCheck /> : "1"}
            </ellipse>
            <p className={page < 2 ? (page === 1 ? "text t-current" : "text t-before") : "text t-after"}>
                סוג פנסיה
            </p>
            <hr className={page < 2 ? (page === 1 ? "line l-current" : "line l-befor") : "line l-after"}>
            </hr>

            <ellipse className={page < 3 ? (page === 2 ? "ellipse e-current" : "ellipse e-before") : "ellipse e-after"}>
                {page > 2 ? <VscCheck /> : "2"}
            </ellipse>
            <p className={page < 3 ? (page === 2 ? "text t-current" : "text t-before") : "text t-after"}>
                נתונים כלליים
            </p>
            <hr className={page < 3 ? (page === 2 ? "line l-current" : "line l-before") : "line l-after"}>
            </hr>

            <ellipse className={page < 4 ? (page === 3 ? "ellipse e-current" : "ellipse e-before") : "ellipse e-after"}>
                {page > 3 ? <VscCheck /> : "3"}
            </ellipse>
            <p className={page < 4 ? (page === 3 ? "text t-current" : "text t-before") : "text t-after"}>
                סכומים ויתרות – נתוני העובד
            </p>
            <hr className={page < 5 ? (page === 4 ? "line l-current" : "line l-before") : "line l-after"}>
            </hr>

            <ellipse className={page < 5 ? (page === 4 ? "ellipse e-current" : "ellipse e-before") : "ellipse e-after"}>
                {page > 4 ? <VscCheck /> : "4"}
            </ellipse>
            <p className={page < 5 ? (page === 4 ? "text t-current" : "text t-before") : "text t-after"}>
                חלקיות משרה
            </p>


        </div>
    );
}
export default Sequence;