import HeaderDesktop from "./LayoutDesktop/Header/HeaderDesktop.jsx";
import FooterDesktop from "./LayoutDesktop/Footer/FooterDesktop.jsx";
import useWindowSize from "../Shared/hooks/useWindowSize.js";
import LayoutDesktop from "./LayoutDesktop/LayoutDesktop";
import LayoutMobile from "./LayoutMobile/LayoutMobile";

function PageLayout({children}){

    const { width, height } = useWindowSize();

    console.log(width)

    if (width < 1180) {
        return (
            <LayoutMobile children={children} />
        );
    } else {
        return (
            <LayoutDesktop children={children} />
        );
    }
}

export default PageLayout