import { ReactNode } from "react"
import { LayoutProps } from "./PageWithLayout"

interface Props {
  children: ReactNode
}

const AdminLayout: LayoutProps =({children}:Props) => {
  return (
    <div>{children}</div>
  )
}

export default AdminLayout