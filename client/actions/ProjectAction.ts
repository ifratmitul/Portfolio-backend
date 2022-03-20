import agent from "../api/agent";
import { ProjectAction } from "../reducers/ProjectReducer";

export const FetchProjects = () => {
  return async (dispatch: any) => {
    const fetchData = async () => {
      let data = await agent.Projects.list();
      return data;
    };

    try {
      const data = await fetchData();
      dispatch(ProjectAction.getProjects(data));
    } catch (error) {
      console.log(error);
    }
  };
};
