import Layout from "../layout/Layout";
import style from "./hero.module.scss";
import Animation from "../UI/Animation";
function Hero() {
  return (
    <div className={style["hero"]}>
      {/* <Animation /> */}
      <section aria-labelledby="hero" className={style["hero__main"]}>
        <div className={style["hero__main--text-box"]}>
          <div className="heading-primary">
            <h1
              className={`heading-primary--main ${style["hero__heading--main"]}`}
            >
              {"Hi there, I'm Ifrat"};
            </h1>

            <div
              className={` ${style["hero__subtitle--box"]} ${style["hero__heading--subtitle"]}`}
            >
              <h4 className={`heading-primary--sub`}>
                Software Engineer
              </h4>
              <a type="button" className="btn-link" href="#project">
                View my work &#8595;
              </a>
            </div>
          </div>
        </div>
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
