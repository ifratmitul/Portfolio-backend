import NavStyle from "./navbar.module.scss";
import Link from "next/link";
import useNavShadow from "../hooks/use-navShadow";

function Navbar() {
  const navShadow = useNavShadow();

  return (
    <nav
      className={`${NavStyle["navbar"]} ${
        navShadow ? NavStyle["navbar__shadow"] : ""
      } `}
    >
      <div className={NavStyle["navbar__logo"]}>
        <Link href="/">
          <a>
            <h2>Ifrat;</h2>
          </a>
        </Link>
      </div>
      <div className={NavStyle["navbar__links"]}>
        <ul className={NavStyle["navbar__links--list"]}>
          <li className={NavStyle["navbar__links--list-item"]}>
            <Link href="/">
              <a className={NavStyle["nav-btn"]}>Home</a>
            </Link>
          </li>
          <li className={NavStyle["navbar__links--list-item"]}>
            <Link href="/projects">
              <a className={NavStyle["nav-btn"]}>Projects</a>
            </Link>
          </li>
          <li className={NavStyle["navbar__links--list-item"]}>
            <Link href="/">
              <a className={NavStyle["nav-btn"]}>Skills</a>
            </Link>
          </li>
          <li className={NavStyle["navbar__links--list-item"]}>
            <Link href="/">
              <a className={NavStyle["nav-btn"]}>Contact</a>
            </Link>
          </li>
          <li className={NavStyle["navbar__links--list-item"]}>
            <a className={NavStyle["nav-btn"]} type="button">
              Icon
            </a>
          </li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
