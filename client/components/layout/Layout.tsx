import Navbar from "../Navbar";
import { ReactNode } from "react";
import { LayoutProps } from "./PageWithLayout";
import Footer from "../footer";

interface Props {
  children: ReactNode;
}

const Layout: LayoutProps = ({ children }: Props) => {
  return (
    <>
      <Navbar />
      <main>{children}</main>
      <Footer />
    </>
  );
};

export default Layout;
