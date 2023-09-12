import { combineReducers } from "redux";
import employeeReducer from './employeeReducer';
import userReducer from "./userReducer";

const allReducers = combineReducers({
    employeeReducer: employeeReducer,
    userReducer : userReducer,
});

export default allReducers;