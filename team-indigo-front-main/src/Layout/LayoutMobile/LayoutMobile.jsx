
import HeaderMobile from "./Header/Header.jsx";
import FooterMobile from "./Footer/FooterMobile.jsx";

export default function LayoutMobile({children}){
    return (
        <div>
            <HeaderMobile></HeaderMobile>
            <div
                // style={{paddingTop:"90px"}}
            >{children}</div>
            <FooterMobile></FooterMobile>
        </div>
    )
}