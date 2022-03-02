import { Education } from "../Model/education";
import * as types from "./types";

export const getEducation = () => ({ type: types.GET_EDUCATION });
export const updateEducation = (data: Education) => ({
  type: types.EDIT_EDUCATION,
  payload: data,
});
export const addEducation = (data: Education) => ({
  type: types.EDIT_EDUCATION,
  payload: data,
});
export const deleteEducation = (id: string) => ({
  type: types.EDIT_EDUCATION,
  payload: id,
});
