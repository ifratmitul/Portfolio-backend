import { NextPage } from 'next'
import type { ReactElement } from 'react'
import Layout from "./Layout"
import AdminLayout from "./AdminLayout"
export type PageWithMainLayoutType = NextPage & { layout: typeof Layout }
export type PageWithAdminLayoutType = NextPage & { layout: typeof AdminLayout }
export type PageWithLayoutType =
 | PageWithMainLayoutType
 | PageWithAdminLayoutType
export type LayoutProps = ({
 children,
}: {
 children: ReactElement
}) => ReactElement
export default PageWithLayoutType
