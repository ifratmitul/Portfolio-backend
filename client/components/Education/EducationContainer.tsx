import style from "./Education.module.scss";
import EducationList from "./EducationList";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { fetchEducationData } from "../../actions/EduAction";
const EducationContainer = () => {
  // const dispatch = useDispatch();
  // useEffect(() => {
    
  //   return () => {};
  // }, [dispatch]);
  return (
    <section className={style["education-container"]}>
      <div className={style["education-container__text"]}>
        <h4>Education</h4>
      </div>
      <div className={style["education-container__list"]}>
        <EducationList />
      </div>
    </section>
  );
};

export default EducationContainer;
