import Layout from "../layout/Layout";
import Image from "next/image";
import heroImage from "../../assets/image/work.svg";
import style from "./hero.module.scss";
import Animation from "../UI/Animation";
function Hero() {
  return (
    <div className={style["hero"]}>
      <Animation />
      <section className={style["hero__main"]}>
        <div className={style["hero__main--text-box"]}>
          <div className="heading-primary">
            <h4 className="heading-primary--sub">{"Hi there, I'm"}</h4>
            <h1 className="heading-primary--main">Ifrat;</h1>
            <h4 className="heading-primary--sub">
              a Software Engineer | Front-end Developer
            </h4>
            <a type="button" className="btn-link" href="#project">
              View my work &#8594;
            </a>
          </div>
        </div>
      </section>
      <section className={style["hero__secondary"]}>
        <Image
          src={heroImage}
          className={style["imagestyle"]}
          objectFit="contain"
        />
      </section>
    </div>
  );
}

Hero.layout = Layout;

// export async function getStaticProps() {
//   const res = await fetch("http://localhost:5000/api/profile");
//   console.log(res);
//   const profile = await res.json();
//   return {
//     props: {
//       profile,
//     },
//   };
// }

export default Hero;
