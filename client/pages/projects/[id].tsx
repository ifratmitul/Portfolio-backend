import { useRouter } from "next/router";
import React from "react";
import { useSelector } from "react-redux";
import Layout from "../../components/layout/Layout";
import { Project } from "../../Model/project";
import style from "./projectDetails.module.scss";

const ProjectDetails = () => {
  const route = useRouter();
  const { id } = route.query;
  const project: Project[] = useSelector((state: any) => state.project);
  const selectedProject = project.find((item: Project) => item.id === id);
  console.log(selectedProject);

  if (!selectedProject) {
    setTimeout(() => {
      route.push("/");
    }, 4000);
    return (
      <div className={style["project-not-found"]}>
        <h1>{"Project Doesn't exit"}</h1>
      </div>
    );
  }
  return (
    <div className={style["project-details"]}>
      <h1>{selectedProject.title}</h1>
      <h2>{id}</h2>
    </div>
  );
};
ProjectDetails.layout = Layout;
export default ProjectDetails;
