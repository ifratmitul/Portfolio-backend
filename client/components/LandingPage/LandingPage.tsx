import Experience from "../Experience/Experience";
import Layout from "../layout/Layout";
import Projects from "../Project/Projects";
import Skill from "../Skill/Skill";
import Hero from "./Hero";

const LandingPage = () => {
  return (
    <>
      <Hero />
      <div className="information-wrapper">
        <Projects />
        <Experience />
        <Skill />
      </div>
    </>
  );
};
LandingPage.layout = Layout;

export default LandingPage;
