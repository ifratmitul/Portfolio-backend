import axios, { AxiosResponse } from "axios";
import { Education } from "../Model/education";

const baseUrl = "http://localhost:5000/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url).then(responseBody),
  delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Education = {
  list: () => request.get<Education[]>(baseUrl + "/education"),
};

const agent = {
  Education,
};

export default agent;
