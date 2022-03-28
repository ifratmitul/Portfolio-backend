import Head from "next/head";
import Layout from "../components/layout/Layout";
import LandingPage from "../components/LandingPage/LandingPage";
import { FetchProjects } from "../actions/ProjectAction";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { fetchEducationData } from "../actions/EduAction";
import { fetchExperienceData } from "../actions/ExperienceAction";
import { fetchSkills } from "../actions/SkillAction";
const Home = () => {

  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(FetchProjects());
    dispatch(fetchEducationData());
    dispatch(fetchExperienceData());
    dispatch(fetchSkills());
    return () => { };
  }, [dispatch]);
  return (
    <>
      <LandingPage />
    </>
  );
};

Home.layout = Layout;

export default Home;
