import Layout from "../layout/Layout";
import ProjectCard from "./ProjectCard";
import style from "./projects.module.scss";

function Projects() {
  return (
    <div className={style["project"]} id="project">
      <section className={style["project__text-box"]}>
        <div className="heading-secondary">
          <h1 className="heading-secondary--main">Projects</h1>
        </div>
      </section>

      <section className={style["project__list"]}>
        <ProjectCard />
      </section>
    </div>
  );
}

Projects.layout = Layout;
export default Projects;
