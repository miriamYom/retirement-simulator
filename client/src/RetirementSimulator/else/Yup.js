// // nice link for YUP:
// // https://www.smashingmagazine.com/2020/10/react-validation-formik-yup/
// // https://www.npmjs.com/package/yup

import * as yup from 'yup';

function Yup(){

    let userSchema = yup.object().shape({
        name: yup.string().required(),
        age: yup.number().required().positive().integer(),
        email: yup.string().email(),
        role : yup.string().required(),
        phoneNumber : yup.string().required(),
        password : yup.string().required(),
        subscriptionPeriodDate : date().default(() => new Date()),
        isSubscriptionPeriodValid : yup.boolean().default()
      });

    return(
        <>
        </>
    );
}
export default Yup;