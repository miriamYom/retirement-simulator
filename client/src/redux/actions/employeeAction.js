export const addDetail = (name, value) => {
    return {
        type: "ADDDETAIL",
        playload: {name, value}
    }
}
export const addDetails = (obj) => {
    return {
        type: "ADDDETAILS",
        playload: obj
    }
}
export const removePensionType = () => {
    return {
        type: "REMOVEPENSIONTYPE"
    }
}