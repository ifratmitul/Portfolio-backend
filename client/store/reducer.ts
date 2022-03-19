import { combineReducers } from "redux";
import EducationSlice from "../reducers/EduReducer";

const reducers = {
  education: EducationSlice.reducer,
};

export default combineReducers(reducers);
