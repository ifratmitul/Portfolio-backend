import Link from "next/link";
import { useSelector } from "react-redux";
import { Skill } from "../../Model/skill";
import SkillList from "./Skill-list";
import style from "./skill.module.scss";

const Skill = () => {

  const skillList: Skill[] = useSelector((state: any) => state.skill);
  
  return (
    <section className={style["skill"]}>
      <div className={style["skill__text"]}>
        <h4>Skills</h4>
        <p>{"I love learning new technologies."}</p>
        <Link href="/">
          <a>See more</a>
        </Link>
      </div>
      <div className={style["skill__list"]}>
        {skillList.length > 0 && (
          <SkillList skills={skillList} />
          // <ul>
          //   {skillList.map((item: Skill) => (
          //     <SkillItem key={item.id} skill={item} />
          //   ))}
          // </ul>
        )}
      </div>
    </section>
  );
};

export default Skill;
