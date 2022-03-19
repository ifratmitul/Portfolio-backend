import "../styles/globals.scss";
import type { AppProps } from "next/app";
import PageWithLayoutType from "../components/layout/PageWithLayout";
import { ReactElement } from "react";
import { Provider } from "react-redux";
import { useStore } from "../store/store";

type AppLayoutProps = AppProps & {
  Component: PageWithLayoutType;
  pageProps: any;
};
function MyApp({ Component, pageProps }: AppLayoutProps) {
  const store = useStore(pageProps.initialReduxState);

  const Layout =
    Component.layout || ((children: ReactElement) => <>{children}</>);
  return (
    <Layout>
      <Provider store={store}>
        <Component {...pageProps} />
      </Provider>
    </Layout>
  );
}
export default MyApp;
