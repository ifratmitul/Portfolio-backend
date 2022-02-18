import Layout from "../layout/Layout";
import ProjectSummery from "./ProjectSummery";
import Hero from "../UI/Hero/Hero";

const LandingPage = () => {
  return (
    <>
      <Hero />
      <ProjectSummery />
      <ProjectSummery />
      <ProjectSummery />
      <ProjectSummery />
    </>
  );
};
LandingPage.layout = Layout;

export default LandingPage;
