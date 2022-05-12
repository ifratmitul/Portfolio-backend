import axios, { AxiosError, AxiosResponse } from "axios";
import { Education } from "../Model/education";
import { Experience } from "../Model/Experience";
import { Project } from "../Model/project";
import { Skill } from "../Model/skill";

axios.defaults.baseURL = "http://localhost:5000/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url).then(responseBody),
  delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Education = {
  list: () => request.get<Education[]>("/education"),
};

const Experience = {
  list: () => request.get<Experience[]>("/experience"),
};

const Skills = {
  list: () => request.get<Skill[]>("/skill"),
};

const Projects = {
  list: () => request.get<Project[]>("/project"),
};

const agent = {
  Education,
  Experience,
  Skills,
  Projects,
};

export default agent;
