import React from "react";
import { dateFormatter } from "../../common/helper";
import { Experience } from "../../Model/Experience";
import style from "./experience-item.module.scss";

interface Props {
  experience: Experience;
}

const ExperienceItem = ({ experience }: Props) => {
  const startDate = dateFormatter(new Date(experience.startDate));
  const endDate = experience.endDate
    ? dateFormatter(new Date(experience.endDate))
    : "Present";

  return (
    <li className={style["experience-item"]}>
      <div className={style["experience-item__info"]}>
        <div className={style["experience-item__info-img"]}>
          <img src={experience.photoUrl} alt="logo" />
        </div>
        <div className={style["experience-item__info-text"]}>
          <h4>{experience.position}</h4>
          <h5>{experience.company}</h5>
          <h5>
            {startDate} - {endDate}
          </h5>
        </div>
      </div>
      <div className={style["experience-item__details"]}>
        {experience.responsibilities}
      </div>
    </li>
  );
};



export default ExperienceItem;
