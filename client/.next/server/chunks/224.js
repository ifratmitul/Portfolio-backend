exports.id = 224;
exports.ids = [224];
exports.modules = {

/***/ 282:
/***/ ((module) => {

// Exports
module.exports = {
	"navbar": "navbar_navbar__U0UgN",
	"navbar__logo": "navbar_navbar__logo___tD6y",
	"navbar__links": "navbar_navbar__links__LJJn9",
	"navbar__links--list": "navbar_navbar__links--list__lTrPH",
	"navbar__links--list-item": "navbar_navbar__links--list-item__RUu2a",
	"nav-btn": "navbar_nav-btn__uGCX7"
};


/***/ }),

/***/ 224:
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";

// EXPORTS
__webpack_require__.d(__webpack_exports__, {
  "Z": () => (/* binding */ layout_Layout)
});

// EXTERNAL MODULE: external "react/jsx-runtime"
var jsx_runtime_ = __webpack_require__(997);
// EXTERNAL MODULE: ./components/navbar.module.scss
var navbar_module = __webpack_require__(282);
var navbar_module_default = /*#__PURE__*/__webpack_require__.n(navbar_module);
// EXTERNAL MODULE: ./node_modules/next/link.js
var next_link = __webpack_require__(664);
// EXTERNAL MODULE: external "@fortawesome/free-solid-svg-icons"
var free_solid_svg_icons_ = __webpack_require__(466);
// EXTERNAL MODULE: external "@fortawesome/react-fontawesome"
var react_fontawesome_ = __webpack_require__(197);
;// CONCATENATED MODULE: ./components/Navbar.tsx





function Navbar() {
    const check = "fa-arrow-down-to-line";
    return(/*#__PURE__*/ (0,jsx_runtime_.jsxs)("nav", {
        className: (navbar_module_default()).navbar,
        children: [
            /*#__PURE__*/ jsx_runtime_.jsx("div", {
                className: (navbar_module_default()).navbar__logo,
                children: /*#__PURE__*/ jsx_runtime_.jsx("h2", {
                    children: "Ifrat;"
                })
            }),
            /*#__PURE__*/ jsx_runtime_.jsx("div", {
                className: (navbar_module_default()).navbar__links,
                children: /*#__PURE__*/ (0,jsx_runtime_.jsxs)("ul", {
                    className: (navbar_module_default())["navbar__links--list"],
                    children: [
                        /*#__PURE__*/ jsx_runtime_.jsx("li", {
                            className: (navbar_module_default())["navbar__links--list-item"],
                            children: /*#__PURE__*/ jsx_runtime_.jsx(next_link["default"], {
                                href: "/",
                                children: /*#__PURE__*/ jsx_runtime_.jsx("a", {
                                    className: (navbar_module_default())["nav-btn"],
                                    children: "Home"
                                })
                            })
                        }),
                        /*#__PURE__*/ jsx_runtime_.jsx("li", {
                            className: (navbar_module_default())["navbar__links--list-item"],
                            children: /*#__PURE__*/ jsx_runtime_.jsx(next_link["default"], {
                                href: "/projects",
                                children: /*#__PURE__*/ jsx_runtime_.jsx("a", {
                                    className: (navbar_module_default())["nav-btn"],
                                    children: "Projects"
                                })
                            })
                        }),
                        /*#__PURE__*/ jsx_runtime_.jsx("li", {
                            className: (navbar_module_default())["navbar__links--list-item"],
                            children: /*#__PURE__*/ jsx_runtime_.jsx(next_link["default"], {
                                href: "/",
                                children: /*#__PURE__*/ jsx_runtime_.jsx("a", {
                                    className: (navbar_module_default())["nav-btn"],
                                    children: "Contact"
                                })
                            })
                        }),
                        /*#__PURE__*/ jsx_runtime_.jsx("li", {
                            className: (navbar_module_default())["navbar__links--list-item"],
                            children: /*#__PURE__*/ jsx_runtime_.jsx(next_link["default"], {
                                href: "/",
                                children: /*#__PURE__*/ (0,jsx_runtime_.jsxs)("a", {
                                    className: (navbar_module_default())["nav-btn"],
                                    children: [
                                        /*#__PURE__*/ jsx_runtime_.jsx(react_fontawesome_.FontAwesomeIcon, {
                                            icon: free_solid_svg_icons_.faFileArrowDown,
                                            style: {
                                                height: '15px'
                                            }
                                        }),
                                        "Resume"
                                    ]
                                })
                            })
                        }),
                        /*#__PURE__*/ jsx_runtime_.jsx("li", {
                            className: (navbar_module_default())["navbar__links--list-item"],
                            children: /*#__PURE__*/ jsx_runtime_.jsx("a", {
                                className: (navbar_module_default())["nav-btn"],
                                type: "button",
                                children: "Icon"
                            })
                        })
                    ]
                })
            })
        ]
    }));
}
/* harmony default export */ const components_Navbar = (Navbar);

;// CONCATENATED MODULE: ./components/layout/Layout.tsx


const Layout = ({ children  })=>{
    return(/*#__PURE__*/ (0,jsx_runtime_.jsxs)(jsx_runtime_.Fragment, {
        children: [
            /*#__PURE__*/ jsx_runtime_.jsx(components_Navbar, {}),
            /*#__PURE__*/ jsx_runtime_.jsx("main", {
                children: children
            })
        ]
    }));
};
/* harmony default export */ const layout_Layout = (Layout);


/***/ })

};
;