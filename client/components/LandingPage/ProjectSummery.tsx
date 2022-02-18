import Layout from "../layout/Layout";
import style from "./projectsummery.module.scss";

function ProjectSummery() {
  return (
    <div className={style["project"]} id="project">
      <section className={style["project__text-box"]}>
        <div className="heading-secondary">
          <h1 className="heading-secondary--main">Projects</h1>
        </div>
      </section>
    </div>
  );
}

ProjectSummery.layout = Layout;
export default ProjectSummery;
