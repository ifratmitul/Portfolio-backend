import React from "react";
import { Project } from "../../Model/project";
import style from "./projectcard.module.scss";

interface Props {
  project: Project;
}

function ProjectCard() {
  return (
    <div className={style["card"]}>
      <div className={style["card-header"]}>
        <img
          src="https://c0.wallpaperflare.com/preview/483/210/436/car-green-4x4-jeep.jpg"
          alt="rover"
        />
      </div>
      {/* <div className={style["card-body"]}>
        <h4>Why is the Tesla Cybertruck designed the way it is?</h4>
        <p>An exploration into the trucks polarising design</p>
      </div> */}
    </div>
  );
}

export default ProjectCard;
