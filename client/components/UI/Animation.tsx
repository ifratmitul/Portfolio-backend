import style from "./animation.module.scss";
function Animation() {
  return (
    <>
      <ul className={style["circles"]}>
        <li>Angular</li>
        <li>Next.js</li>
        <li>CSS</li>
        <li>React.js</li>
        <li>C#</li>
        <li>JS</li>
        <li>.NET</li>
        <li>undefined;</li>
        <li>;</li>
        <li>TS</li>
        <li>{"<></>"}</li>
        <li>{"Coffee = code;"}</li>
      </ul>
    </>
  );
}

export default Animation;
