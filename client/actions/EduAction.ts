import agent from "../api/agent";
import { EduAction } from "../reducers/EduReducer";

export const fetchEducationData = () => {
  return async (dispatch: any) => {
    const fetchData = async () => {
      let data = await agent.Education.list();
      return data;
    };

    try {
      const data = await fetchData();
      dispatch(EduAction.getEducationList(data));
    } catch (error) {
      console.log(error);
    }
  };
};
