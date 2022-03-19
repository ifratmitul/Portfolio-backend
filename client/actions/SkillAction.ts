import agent from "../api/agent";
import { SkillActions } from "../reducers/SkillReducer";

export const fetchSkills = () => {
  return async (dispatch: any) => {
    const fetchData = async () => {
      let data = await agent.Skills.list();
      return data;
    };

    try {
      const data = await fetchData();
      dispatch(SkillActions.getSkills(data));
    } catch (error) {
      console.log(error);
    }
  };
};
