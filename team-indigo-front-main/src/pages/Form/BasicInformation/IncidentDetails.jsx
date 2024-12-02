import Input from "../../../Shared/ui/Input.jsx";
import DatePicker from "../../../Shared/ui/DatePicker.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import { Collapse, IconButton, Typography } from "@mui/material";
import { useState, useEffect } from "react";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";
import { getBuildings } from "../../../Shared/API/getBuildings.jsx";

export default function IncidentDetails({ reporterInfo, onChange }) {
    const [isExpanded, setIsExpanded] = useState(true);
    const [buildings, setBuildings] = useState([]);
    const [validationErrors, setValidationErrors] = useState({
        date: "",
        time: "",
        location: "",
        workHours: "",
        whileWorking: "",
        description: "",
        environment: "",
    });


    console.log(reporterInfo.incident)



    useEffect(() => {
        const fetchBuildings = async () => {
            try {
                const buildingsResponse = await getBuildings();
                setBuildings(buildingsResponse);
            } catch (error) {
                console.error('Error fetching buildings:', error);
            }
        };
        fetchBuildings();
    }, []);


    const toggleVisibility = () => {
        setIsExpanded(!isExpanded);
    };

    const handleChange = (e) => {

        console.log(e)

        console.log(e.target.value)

        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;

        // Reset validation errors
        setValidationErrors({
            date: "",
            time: "",
            location: "",
            workHours: "",
            whileWorking: "",
            description: "",
            environment: "",
            
        });

        onChange({
            ...reporterInfo,
            incident: {
                ...reporterInfo.incident,
                [e.target.name]: value
            }
        });

        // Validation checks
        if (e.target.required && value.trim() === "") {
            setValidationErrors({
                ...validationErrors,
                [e.target.name]: `${e.target.label} is required`,
            });
        }

        if (e.target.name === "buildings" && e.target.value.trim() === "") {
            setValidationErrors({
                ...validationErrors,
                buildings: "Buildings selection is required",
            });
        }
    };

    return (
        
        <div className="border bg-white rounded-md mb-4">
            
            <div onClick={toggleVisibility} className="flex flex-row justify-between items-center px-3 pt-3 border-b " >
                <p className="text-2xl">
                    Incident Details
                </p>
                <IconButton className="pb-3">
                    <ExpandMoreIcon style={{ transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)' }} />
                </IconButton>
            </div>
            <Collapse in={isExpanded}>
                <DatePicker
                    name={"date"}
                    type={"date"}
                    className="mx-5"
                    onChange={handleChange}
                    value={reporterInfo.incident.date}
                    error={validationErrors.date}
                />
                <DatePicker
                    name={"time"}
                    type={"time"}
                    className="mx-5"
                    onChange={handleChange}
                    value={reporterInfo.incident.time}
                    error={validationErrors.time}
                />


                {buildings && buildings.length > 0 && (
                <CheckboxRadioGroup
                        name={"location"}
                        label={"Which building did the incident take place at?"}
                        className={"mx-5"}
                        type={'radio'}
                        options={buildings.map((building) => `${building.address}`)}
                        onChange={handleChange}
                        value={reporterInfo.incident.location}
                    />
                )}

                <CheckboxRadioGroup
                    name={"workHours"}
                    label={"Did the incident take place during work hours?"}
                    type={'radio'}
                    className={"mx-5"}
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={reporterInfo.incident.workHours === true ? "yes" : reporterInfo.incident.workHours === false ? "no" : ''}
                    error={validationErrors.workHours}
                />

                <CheckboxRadioGroup
                    name={"whileWorking"}
                    label={"Did the incident take place while working?"}
                    type={'radio'}
                    className={"mx-5"}
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={reporterInfo.incident.whileWorking === true ? "yes" : reporterInfo.incident.whileWorking === false ? "no" : ''}
                    error={validationErrors.whileWorking}
                />

                <Input
                    name="description"
                    label="Description"
                    className="mx-5"
                    placeholder="What is your interpretation of what happened?"
                    required={true}
                    onChange={handleChange}
                    value={reporterInfo.incident.description}
                    error={validationErrors.description}
                />

                <Input
                    name="environment"
                    label="Environment"
                    className="mx-5 mb-3"
                    placeholder="What has been released and how much? "
                    required={true}
                    onChange={handleChange}
                    value={reporterInfo.incident.environment}
                    error={validationErrors.environment}
                />
                {Object.values(validationErrors).some((error) => error !== "") && (
                    <Typography color="error">Please fill in all fields under "Incident Information".</Typography>
                )}
            </Collapse>
        </div>
    );
}
