const initialState = {
    "pensionType": "BudgetPension",
    "name": "string",
    "id": 0,
    "birthDate": "2023-05-30T10:05:48.071Z",
    "startWorkDate": "2023-05-30T10:05:48.071Z",
    "retirementDate": "2023-05-30T10:05:48.071Z",
    "reason": 0,
    "advanceNotice": 99,
    "isClothingForAudienceMembers": true,
    "isMonthlyClothingPayment": true,
    "isThreeLevel": true,
    "monthOfClothingPayment": 1,
    "isCurrentYear": true,
    "isMonthlyRecoveryPayment": true,
    "numberOfDaysOfRecoveryToBePaid": 0,
    "recoveryPaymentMonth": 1,
    "lastPartTimeJob": 0,
    "partTimeJobCurrentYear": 0,
    "partTimeJobLastYear": 0,
    "salaryDetermines": 0,
    "remainingSickDays": 0,
    "isFullAccrual": true,
    "remainingVacationDaysInRetirement": 0,
    "isFiveBusinessDays": true,
    "isAggregationByParts": true,
    "workPeriods": [[]]

};

const employeeReducer = (state = initialState, action) => {
    switch (action.type) {
        case "ADDDETAIL": {
            state[action.playload.name] = action.playload.value;
            return state;
        }
        case "ADDDETAILS": {
            // Object.keys(action.playload.obj).forEach(key => {
            //     state[key] = action.playload.obj[key];
            // });
            console.log(initialState);
            return state;
        }
        case "REMOVEPENSIONTYPE": {
            delete state["pensionType"];
            return state;
        }
    }
    return state;
}
export default employeeReducer;