import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import ManagerDetails from "./ManagerDetails.jsx";
import AandE from "./AandE.jsx";
import Hospital from "./Hospital.jsx";
import GPDetails from "./GPDetails.jsx";
import EmergencyResponse from "./EmergencyResponse.jsx";
import {useState} from "react";
import {Collapse, IconButton} from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";

export default function InjuredPerson({ injuredPersonInfo, onChange }) {
    const handleChange = (e) => {
        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                [e.target.name]: value
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
                    Injured Person Details
                </p>
                <IconButton className="pb-3">
                    <ExpandMoreIcon style={{ transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)'}} />
                </IconButton>
            </div>
            <Collapse in={isExpanded}>
                <Input
                    name="name"
                    label="Name"
                    className="mx-5"
                    placeholder="Enter name"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.name}
                />
                <Input
                    name="department"
                    label="Department"
                    className="mx-5"
                    placeholder="Department / Location"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.department}
                />
                <Input
                    name="phone"
                    label="Phone"
                    className="mx-5"
                    placeholder="Phone Number"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.phone}
                />
                <Input
                    name="email"
                    label="Email"
                    className="mx-5"
                    placeholder="Email"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.email}
                />
                <Input
                    name="position"
                    label="Position"
                    className="mx-5"
                    placeholder="Position"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.position}
                />
                <CheckboxRadioGroup
                    name="status"
                    label="Status"
                    className="mx-5"
                    type="radio"
                    options={["Employee", "Temporary Worker", "External Company Employee", "Visitor", "Passer-by"]}
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.status}
                />

                <ManagerDetails injuredPersonInfo={injuredPersonInfo} onChange={onChange} />

                <CheckboxRadioGroup
                    name="goTo"
                    label="Did the injured person go to any of the following?"
                    className="mx-5"
                    type="radio"
                    options={["None", "Emergency Response", "General practitioner", "A&E", "Hospitalization"]}
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.goTo}
                />
                {injuredPersonInfo.injuredPerson.goTo === "A&E" ?
                    <AandE injuredPersonInfo={injuredPersonInfo} onChange={onChange} />
                    : injuredPersonInfo.injuredPerson.goTo === "Hospitalization" ?
                            <Hospital injuredPersonInfo={injuredPersonInfo} onChange={onChange} />
                            : injuredPersonInfo.injuredPerson.goTo === "General practitioner" ?
                                    <GPDetails injuredPersonInfo={injuredPersonInfo} onChange={onChange} />
                                    : injuredPersonInfo.injuredPerson.goTo === "Emergency Response" ?
                                            <EmergencyResponse injuredPersonInfo={injuredPersonInfo} onChange={onChange} />
                                            :
                                            null


                }
            </Collapse>
        </div>
    );
}
