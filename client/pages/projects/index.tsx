import Layout from "../../components/layout/Layout";
import style from "./project-container.module.scss";
import Projects from "../../components/Project/Projects";
import { Skill } from "../../Model/skill";
import { useDispatch, useSelector } from "react-redux";
import SkillList from "../../components/Skill/Skill-list";
import { FetchProjects } from "../../actions/ProjectAction";
import { fetchSkills } from "../../actions/SkillAction";
import { useEffect } from "react";

const Project = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(FetchProjects());
    dispatch(fetchSkills());
    return () => { };
  }, [dispatch]);
  const skillList: Skill[] = useSelector((state: any) => state.skill);
  console.log(skillList);
  
  return (
    <div className={style["project-container"]}>
      <div className={`heading-primary ${style["project__title"]} `}>
        <h1 className="heading-primary--sub">Projects</h1>
        <p className="heading-secondary--sub">
          All of the following projects are my personal project. Please visit my{" "}
          <a href="https://github.com/ifratmitul">Github</a> profile to see more
          details.
        </p>
      </div>

      <section className={style["project-cards"]}>
        <Projects providedIn="PROJECT" />
      </section>

      {skillList.length > 0 && (
        <section className={style['project__technology']}>
          <div className={`heading-primary ${style["project__title"]} `}>
            <h1 className="heading-primary--sub">
              {"Technologies I've worked with"}
            </h1>
            <p className="heading-secondary--sub">
              I enjoy working
              with different technologies. These are few of the technologies i
              have worked with in different projects.
            </p>
          </div>
          <div className={style['project__technology--list']}>
            <SkillList skills={skillList} />
          </div>
        </section>
      )}
    </div>
  );
};

Project.layout = Layout;
export default Project;
