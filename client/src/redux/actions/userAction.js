export const userLogin = (obj) => {
    console.log("obj",obj);
    return {
        type: "USERLOGIN",
        playload: {obj}
    }
}