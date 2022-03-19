import agent from "../api/agent";
import { ExperienceAction } from "../reducers/ExperienceReducer";

export const fetchExperienceData = () => {
  return async (dispatch: any) => {
    const fetchData = async () => {
      let data = await agent.Experience.list();
      return data;
    };

    try {
      const data = await fetchData();
      dispatch(ExperienceAction.getExperience(data));
    } catch (error) {
      console.log(error);
    }
  };
};
