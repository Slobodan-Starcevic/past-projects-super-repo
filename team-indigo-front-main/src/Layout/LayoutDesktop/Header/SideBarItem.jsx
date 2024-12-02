import {NavLink} from "react-router-dom";

export default function SideBarItem({name, link}){
    let icon;
    switch(name){
        case "Create Report":
            icon = <i class="fa-solid fa-pen-to-square fa-lg"></i>;
            break;
        case "View Reports":
            icon = <i class="fa-solid fa-list fa-lg"></i>;
            break;
        case "Statistic":
            icon = <i class="fa-solid fa-chart-simple fa-lg"></i>;
            break;
        case "Buildings":
            icon = <i className="fa-regular fa-building fa-lg"></i>;
            break;
        default:
            icon = null;
    }

    return(
    <div className="flex items-start ml-[30px] my-5 font-thin">
        <NavLink 
        to={link} 
        className="relative text-decoration-none text-sm md:text-md lg:text-xl text-main-blue hover:font-light duration-300">
            <span className="absolute">{icon}</span>
            <span className="ml-10">{name}</span>
        </NavLink>
    </div>
    )
}