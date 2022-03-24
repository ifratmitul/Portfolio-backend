import { createSlice } from "@reduxjs/toolkit";
import { Project } from "../Model/project";

const InitialProjectState: Project[] = [];

const ProjectSlice = createSlice({
  name: "project",
  initialState: InitialProjectState,
  reducers: {
    getProjects(state, data) {
      state = [...data.payload];
      return state;
    },
  },
});
export const ProjectAction = ProjectSlice.actions;
export default ProjectSlice;
