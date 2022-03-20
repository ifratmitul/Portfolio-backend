import React from "react";
import { Project } from "../../Model/project";
import style from "./projectcard.module.scss";
import Link from "next/link";

interface Props {
  project: Project;
}

function ProjectCard({ project }: Props) {
  return (
    <div className={style["card"]}>
      <div className={style["card__image"]}>
        <img
          src={
            project?.photos[0].url ||
            "https://www.springboard.com/blog/wp-content/uploads/2021/10/shutterstock_1702515220-1.jpg"
          }
          alt="rover"
        />
      </div>
      <div className={style["card__content"]}>
        <h2 className={style["card__title"]}>{project?.title}</h2>
        <p className={style["card__body"]}>{truncate(project?.details)}</p>
        <Link href={"/projects/" + project.id}>
          <a className={style["card__btn"]}>Learn More</a>
        </Link>
      </div>
    </div>
  );
}

const truncate = (str: string): string => {
  return str.length > 130 ? str.substring(0, 130) + "..." : str;
};

export default ProjectCard;
