import { Education } from "../Model/education";
import { createSlice } from "@reduxjs/toolkit";

const initialEducationState: Education[] = [];

const EducationSlice = createSlice({
  name: "edu",
  initialState: initialEducationState,
  reducers: {
    getEducationList(state, data) {
      state = [...data.payload];

      return state;
    },
  },
});
export const EduAction = EducationSlice.actions;
export default EducationSlice;
