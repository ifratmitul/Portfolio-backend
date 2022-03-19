import Link from "next/link";
import style from "./footer.module.scss";

function Footer() {
  return (
    <footer className={style["footer"]}>
      <section className={style["footer__copyright"]}>
        <p>&copy; All rights reserved</p>
        <p>
          This web application was developed using .NET6 and Next.js. Developed
          and maintained by Ifrat;
        </p>
      </section>
      <section className={style["footer__info"]}>
        <h2>Find me in</h2>
        <ul>
          <li>
            <a target="_blank">Linkedin</a>
          </li>
          <li>
            <a target="_blank">Github</a>
          </li>
          <li>
            <Link href="/">
              <a>Website</a>
            </Link>
          </li>
        </ul>
      </section>
    </footer>
  );
}

export default Footer;
