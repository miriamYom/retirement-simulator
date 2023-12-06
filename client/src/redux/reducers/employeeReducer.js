const initialState = {
    Name: '',
    ID: '',
    PensionType: '',
    BirthDate: '',
    StartWorkDate: '',
    RetirementDate: '',
    reason: '',
    advanceNotice: '',
    IsClothingForAudienceMembers: true,
    IsMonthlyClothingPayment: true,
    IsThreeLevel: true,
    monthOfClothingPayment: '',
    IsCurrentYear: true,
    IsMonthlyRecoveryPayment: true,
    numberOfDaysOfRecoveryToBePaid: 1,
    recoveryPaymentMonth: '',
    workPeriods: [[], []],
    LastPartTimeJob: 0,
    PartTimeJobCurrentYear: 0,
    PartTimeJobLastYear: 0,
    SalaryDetermines: 0,
    RemainingSickDays: 0,
    IsFullAccrual: true,
    RemainingVacationDaysInRetirement: 0,
    IsFiveBusinessDays: true,
    IsAggregationByParts: true
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