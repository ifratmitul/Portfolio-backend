import { createSlice } from "@reduxjs/toolkit";
import { Skill } from "../Model/skill";

const initialSkillState: Skill[] = [];

const SkillSlice = createSlice({
  name: "skill",
  initialState: initialSkillState,
  reducers: {
    getSkills(state, data) {
      state = [...data.payload];
      return state;
    },
  },
});
export const SkillActions = SkillSlice.actions;
export default SkillSlice;
