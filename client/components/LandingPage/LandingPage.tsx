import Layout from "../layout/Layout";
import Projects from "../Project/Projects";
import Hero from "./Hero";

const LandingPage = () => {
  return (
    <>
      <Hero />
      <Projects />
    </>
  );
};
LandingPage.layout = Layout;

export default LandingPage;
