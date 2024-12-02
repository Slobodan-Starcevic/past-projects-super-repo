import HeaderDesktop from "./Header/HeaderDesktop.jsx";
import FooterDesktop from "./Footer/FooterDesktop.jsx";

export default function LayoutDesktop({children}){
    return (
        <div>
            <div>
                <HeaderDesktop></HeaderDesktop>
                <div className='ml-[12%]'>{children}</div>
            </div>
            {/*<FooterDesktop></FooterDesktop>*/}
        </div>
    )
}