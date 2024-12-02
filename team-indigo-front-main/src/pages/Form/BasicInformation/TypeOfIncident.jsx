import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import { useState } from "react";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";
import { Collapse, IconButton, Typography } from "@mui/material";

export default function TypeOfIncident({ typeOfIncidentInfo, onChange }) {
    const [isExpanded, setIsExpanded] = useState(true);
    const [validationErrors, setValidationErrors] = useState({
        type: "",
    });

    const toggleVisibility = () => {
        setIsExpanded(!isExpanded);
    };

    const handleChange = (e) => {
        const { name, value, checked } = e.target;

        // Reset validation errors
        setValidationErrors({
            type: "",
        });

        if (name === "type") {
            const updatedTypes = checked
                ? [...(typeOfIncidentInfo.incident.typeOfIncident || []), value]
                : typeOfIncidentInfo.incident.typeOfIncident.filter(type => type !== value);

            onChange({
                ...typeOfIncidentInfo,
                incident: {
                    ...typeOfIncidentInfo.incident,
                    typeOfIncident: updatedTypes
                }
            });

            // Validation checks
            if (updatedTypes.length === 0) {
                setValidationErrors({
                    type: "Please select at least one type of incident",
                });
            }
        } else {
            const updatedValue = value === "yes" ? true : value === "no" ? false : value;
            onChange({
                ...typeOfIncidentInfo,
                reporter: {
                    ...typeOfIncidentInfo.reporter,
                    [name]: updatedValue
                }
            });
        }
    }

    return (
        <div className="border bg-white rounded-md my-4">
            <div onClick={toggleVisibility} className="flex flex-row justify-between items-center px-3 pt-3 border-b " >
                <p className="text-2xl">
                    Type Of Incident
                </p>
                <IconButton className="pb-3">
                    <ExpandMoreIcon style={{ transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)' }} />
                </IconButton>
            </div>
            <Collapse in={isExpanded} className="mx-5">
                <CheckboxRadioGroup
                    name={"type"}
                    label={"Type"}
                    type={'checkbox'}
                    className="mb-3"
                    options={["Fire", "Evacuation", "Personal Injury", "Damage"]}
                    value={typeOfIncidentInfo.incident.typeOfIncident}
                    onChange={handleChange}
                />
                {validationErrors.type && (
                    <Typography color="error">{validationErrors.type}</Typography>
                )}
            </Collapse>
        </div>
    );
}
