import NavStyle from "./navbar.module.scss";
import Image from "next/image";
import Logo from "./../assets/image/logo.png";
import Link from "next/link";
import { faFileArrowDown } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

function Navbar() {
  const check = "fa-arrow-down-to-line"
  return (
    <nav className={NavStyle["navbar"]}>
      <div className={NavStyle["navbar__logo"]}>
        {/* <Image src={Logo} title="" layout="fill" objectFit="contain" /> */}
        <h2>Ifrat;</h2>
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
              <a className={NavStyle["nav-btn"]}>Contact</a>
            </Link>
          </li>
          <li className={NavStyle["navbar__links--list-item"]}>
            <Link href="/">
              <a className={NavStyle["nav-btn"]}>
              <FontAwesomeIcon icon={faFileArrowDown} style= {{height: '15px'}} />
                Resume</a>
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
