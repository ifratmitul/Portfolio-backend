import { Skill } from "../../Model/skill";
import style from "./skill-item.module.scss";

interface Props {
  skill: Skill;
}

const SkillItem = ({ skill }: Props) => {
  return (
    <li className={style["skill-card"]}>
      <img src={skill.photoUrl} className={style["skill-card__img"]} alt="" />
    </li>
  );
};

export default SkillItem;
