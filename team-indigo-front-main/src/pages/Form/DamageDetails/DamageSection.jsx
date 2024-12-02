import Input from "../../../Shared/ui/Input.jsx";
import {useState} from "react";
import {Collapse, IconButton} from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";

export default function DamageSection({ damageInfo, onChange }) {
    const handleChange = (e) => {
        onChange({
            ...damageInfo,
            damage: {
                ...damageInfo.damage,
                [e.target.name]: e.target.value
            }
        });
    };

    const [isExpanded, setIsExpanded] = useState(true);

    const toggleVisibility = () => {
        setIsExpanded(!isExpanded);
    };

    return (
        <div className="border bg-white rounded-md mb-4">
            <div onClick={toggleVisibility} className="flex flex-row justify-between items-center px-3 pt-3 border-b " >
                <p className="text-2xl">
                    Damage
                </p>
                <IconButton className="pb-3" >
                    <ExpandMoreIcon style={{ transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)'}} />
                </IconButton>
            </div>
            <Collapse in={isExpanded}>
                <Input
                    name="description"
                    label="Damage"
                    className="mx-5 mb-3"
                    placeholder="Enter damage"
                    required={true}
                    onChange={handleChange}
                    value={damageInfo.damage.description}
                />
            </Collapse>
        </div>
    );
}
