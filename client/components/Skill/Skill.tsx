import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchSkills } from "../../actions/SkillAction";
import { Skill } from "../../Model/skill";
import SkillItem from "./Skill-item";
import style from "./skill.module.scss";

const Skill = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(fetchSkills());
    return () => {};
  }, [dispatch]);

  const skillList: Skill[] = useSelector((state: any) => state.skill);
  console.log(skillList);

  return (
    <section className={style["skill"]}>
      <div className={style["skill__list"]}>
        {skillList.length > 0 && (
          <ul>
            {skillList.map((item: Skill) => (
              <SkillItem key={item.id} skill={item} />
            ))}
          </ul>
        )}
      </div>
      <div className={style["skill__text"]}>
        <h4>Skills</h4>
        <p>{"I love learning new technologies"}</p>
      </div>
    </section>
  );
};

export default Skill;
