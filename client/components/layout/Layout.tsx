import Navbar from "../Navbar";
import { ReactNode } from "react";
import { LayoutProps } from "./PageWithLayout";

interface Props {
  children: ReactNode
}

const Layout:LayoutProps = ({children}:Props)  =>{
  return (
    <>
    <Navbar/>
    <main>{children}</main>
    </>
  )
}

export default Layout