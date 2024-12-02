import {Link} from "react-router-dom";

export default function MenuBarItem({name, link, onSelect}){
    return(
        <Link to={link} onClick={onSelect} className="text-decoration-none flex-grow">
            <div className="text-3xl w-full text-main-blue text-center">
                {name}
            </div>
        </Link>
    )
}