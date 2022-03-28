import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchExperienceData } from "../../actions/ExperienceAction";
import { Experience } from "../../Model/Experience";
import ExperienceItem from "./Experience-item";
import style from "./experience.module.scss";

const Experience = () => {

  const experienceList: Experience[] = useSelector(
    (state: any) => state.experience
  );
  return (
    <section className={style["experience"]}>
      <div className={style["experience__details"]}>
        <h4>Work Experience</h4>
      </div>
      <div className={style["experience__list"]}>
        {experienceList.length && (
          <ul>
            {experienceList.map((item: Experience) => (
              <ExperienceItem key={item.id} experience={item} />
            ))}
          </ul>
        )}
      </div>
    </section>
  );
};

export default Experience;
