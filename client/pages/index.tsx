import Head from "next/head";
import Layout from "../components/layout/Layout";
import LandingPage from "../components/LandingPage/LandingPage";
const Home = () => {
  return (
    <>
      <Head>
        <title>Ifrats Portfolio</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <LandingPage />
    </>
  );
};

Home.layout = Layout;

export default Home;
