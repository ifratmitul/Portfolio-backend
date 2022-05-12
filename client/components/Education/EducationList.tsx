import { useSelector } from "react-redux";
import { Education } from "../../Model/education";
import EducationItem from "./Education-item";
import style from "./Education.module.scss";

const EducationList = () => {
  const Education: Education[] = useSelector((store: any) => store.education);
  return (
    <ul className={style["education__list"]}>
      {Education.length > 0 &&
        Education.map((item: Education) => (
          <EducationItem key={item.id} education={item} />
        ))}
    </ul>
  );
};

export default EducationList;
