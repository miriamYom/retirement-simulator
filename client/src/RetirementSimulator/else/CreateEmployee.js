
const retirementReason = {
    retirementAge: "retirementAge", // גיל פרישה
    resignation: "resignation", // התפטרות
    dismissal: "dismissal", // פיטורין
    retirementForHealthReasons: "retirementForHealthReasons", //סיבה רפואית 
    death: "death" // מוות
}


function CreateEmployee() {
    let employee = {};
    employee.name = "my-name";
    employee.birthdate = new Date(1 / 1 / 1970);
    employee.startWorkDate = new Date(12 / 12 / 2002);
    employee.retirementDate = new Date(28 / 4 / 2023);
    employee.reason = "RetirementReason.retirementAge";
    employee.advanceNotice = "MonthOrTwoOrTree.month";
    employee.isClothingForAudienceMembers = true;
    employee.isMonthlyClothingPayment = false;
    employee.isThreeLevel = true;
    employee.monthOfClothingPayment = "March";
    employee.isCurrentYear = false;
    employee.isMonthlyRecoveryPayment = true;
    employee.numberOfDaysOfRecoveryToBePaid = 10;
    employee.recoveryPaymentMonth = "November";

    console.log(employee);
    function createPension() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: `"${employee}"`
        };
        fetch(`https://localhost:7049/RentiermentSimulator/CreatePensionService?pensionType=AccrualPensionService`, requestOptions)
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(error => {
                alert({ errorMessage: error.toString() });
                console.error('There was an error!\n', error);
            });

    }

    return (
        <>
            <button onClick={createPension}>Calculate!!!</button>
        </>
    )
}
export default CreateEmployee;