import { combineReducers } from "redux";
import EducationSlice from "../reducers/EduReducer";
import ExperienceSlice from "../reducers/ExperienceReducer";
import SkillSlice from "../reducers/SkillReducer";

const reducers = {
  education: EducationSlice.reducer,
  experience: ExperienceSlice.reducer,
  skill: SkillSlice.reducer,
};

export default combineReducers(reducers);
