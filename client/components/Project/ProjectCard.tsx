import React from "react";
import { Project } from "../../Model/project";
import style from "./projectcard.module.scss";
import { useSelector } from "react-redux";
import { Education } from "../../Model/education";

interface Props {
  project: Project;
}

function ProjectCard() {
  return (
    <div className={style["card"]}>
      <div className={style["card__image"]}>
        <img
          src="https://www.springboard.com/blog/wp-content/uploads/2021/10/shutterstock_1702515220-1.jpg"
          alt="rover"
        />
      </div>
      <div className={style["card__content"]}>
        <h2 className={style["card__title"]}>Something awesome</h2>
        <p className={style["card__body"]}>
          Lorem, ipsum dolor sit amet consectetur adipisicing elit.
          Consequuntur, eos quasi. Alias qui dolore quae quos officia, maiores
          cum sequi.
        </p>
        <a href="#" className={style["card__btn"]}>
          Learn More
        </a>
      </div>
    </div>
  );
}

export default ProjectCard;
