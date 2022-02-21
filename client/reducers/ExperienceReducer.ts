import { createSlice } from "@reduxjs/toolkit";
import { Experience } from "../Model/Experience";

const initialExperienceState: Experience[] = [];

const ExperienceSlice = createSlice({
  name: "exp",
  initialState: initialExperienceState,
  reducers: {
    getExperience(state, data) {
      state = [...data.payload];
      return state;
    },
  },
});
export const ExperienceAction = ExperienceSlice.actions;
export default ExperienceSlice;
