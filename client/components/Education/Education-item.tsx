import React from "react";
import { dateFormatter } from "../../common/helper";
import { Education } from "../../Model/education";
import style from './Education.module.scss';
interface Props {
  education: Education;
}

const EducationItem = ({ education }: Props) => {
  const startDate = dateFormatter(new Date(education.startDate));
  const endDate = education.endDate
    ? dateFormatter(new Date(education.endDate))
    : "Present";
  return (
    <li className={style["education-item"]}>
    <div className={style["education-item__info"]}>
      <div className={style["education-item__info-img"]}>
        <img src={education.logo.url} alt="logo" />
      </div>
      <div className={style["education-item__info-text"]}>
        <h4>{education.institution}</h4>
        <h5>{education.major}</h5>
        <h5>
          {startDate} - {endDate}
        </h5>
      </div>
    </div>
  </li>
  );
};

export default EducationItem;
