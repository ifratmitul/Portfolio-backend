import Link from "next/link";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { FetchProjects } from "../../actions/ProjectAction";
import { Project } from "../../Model/project";
import Layout from "../layout/Layout";
import ProjectCard from "./ProjectCard";
import style from "./projects.module.scss";

function Projects() {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(FetchProjects());
    return () => {};
  }, [dispatch]);

  const projects: Project[] = useSelector((state: any) => state.project);
  const topProjects: Project[] =
    projects?.length > 3 ? projects.slice(0, 3) : projects;

  console.log(topProjects);

  return (
    <section
      aria-labelledby="project"
      className={style["project"]}
      id="project"
    >
      <section className={style["project__text-box"]}>
        <h1 className="heading-primary--sub">Projects</h1>
        <p>
          These are few of my top projects. See more of my projects
          <Link href="/projects">
            <a> here </a>
          </Link>
        </p>
      </section>

      <section className={style["project__list"]}>
        {topProjects?.length > 0 &&
          topProjects.map((item: Project) => (
            <ProjectCard key={item.id} project={item} />
          ))}
      </section>
    </section>
  );
}

Projects.layout = Layout;
export default Projects;
