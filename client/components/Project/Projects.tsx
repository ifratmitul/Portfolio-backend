import Layout from "../layout/Layout";
import ProjectCard from "./ProjectCard";
import style from "./projects.module.scss";

function Projects() {
  return (
    <section
      aria-labelledby="project"
      className={style["project"]}
      id="project"
    >
      <section className={style["project__text-box"]}>
        <h1 className="heading-primary--sub">Projects</h1>
      </section>

      <section className={style["project__list"]}>
        <ProjectCard />
        <ProjectCard />
        <ProjectCard />
      </section>
    </section>
  );
}

Projects.layout = Layout;
export default Projects;
