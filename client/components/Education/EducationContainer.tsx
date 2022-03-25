import style from "./Education.module.scss";
import EducationList from "./EducationList";

const EducationContainer = () => {
  return (
    <section className={style["education-container"]}>
      <div className={style["education-container__text"]}></div>
      <div className={style["education-container__list"]}>
        <EducationList />
      </div>
    </section>
  );
};

export default EducationContainer;
