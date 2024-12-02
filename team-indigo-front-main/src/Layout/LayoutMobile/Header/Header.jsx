
import "./HeaderMobile.css"
import {useState} from "react";
import {Link} from "react-router-dom";
import logo from "../../../assets/img/logo.jpeg"
import menu from "../../../assets/img/menuIcon.png"
import closeMenu from "../../../assets/img/closeMenu.png"
import logOut from "../../../assets/img/logoutIconRed.png"
import MenuBarItem from "./MenuBarItem";
import {useMsal} from "@azure/msal-react";



function HeaderMobile() {
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const closeMenu = () => {
        setIsMenuOpen(false);
    };
    const {instance, accounts} = useMsal();
    const account = accounts[0];

    const handleLogout = () => {
        instance.logoutRedirect();
    }
    return (
        <div>
            <div className="fixed-bottom bg-white z-10 shadow-lg">
                <div className="container-lg mx-auto p-3 z-9 px-5 flex justify-between items-center">
                    <div className="flex items-center">
                        <Link to="/" className="cursor-pointer">
                            <img src={logo} alt="Logo" className="h-14" />
                        </Link>
                    </div>
                    <div className="flex items-center">
                        <img src={ !isMenuOpen ? menu : closeMenu} className="w-[40px]" alt="Menu" onClick={() => setIsMenuOpen(!isMenuOpen)}/>
                    </div>
                </div>
            </div>

            <div className={`fixed z-10 top-0 left-0 w-full h-screen bg-white transform transition-transform duration-500 ${isMenuOpen ? 'translate-y-0' : 'translate-y-full'}`}>
                <div className="flex pt-4 pb-2 flex-row-reverse items-center border-b">
                    <img onClick={() => handleLogout()} src={logOut} className="h-8" alt="" />
                    <p className="text-xl mx-3 m-0 font-light text-dark-blue" >
                        {account.username}
                    </p>
                </div>
                <div className="flex flex-col h-[75%] pb-0 p-5">
                    <MenuBarItem name="Report" link="/post" onSelect={closeMenu} />
                    <MenuBarItem name="Dashboard" link="/dashboard?page=1" onSelect={closeMenu} />
                    <MenuBarItem name="Statistic" link="/statistic" onSelect={closeMenu} />

                </div>
            </div>
        </div>
    );
}

export default HeaderMobile
