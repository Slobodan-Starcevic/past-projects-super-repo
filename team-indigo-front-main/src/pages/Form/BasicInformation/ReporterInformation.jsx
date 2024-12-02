import Input from "../../../Shared/ui/Input.jsx";
import { Collapse, IconButton, Typography } from "@mui/material";
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { useEffect, useState } from "react";

export default function ReporterInformation({ reporterInfo, onChange }) {
    const [isExpanded, setIsExpanded] = useState(true);

    const toggleVisibility = () => {
        setIsExpanded(!isExpanded);
    };

    const [validationErrors, setValidationErrors] = useState({
        name: "",
        department: "",
        phone: "",
        email: "",
    });

    const phoneRegex = /^\+(?:[0-9] ?){6,14}[0-9]$/;

    const handleChange = (e) => {
        const {name, value} = e.target;
        const updatedValue = value === "yes" ? true : value === "no" ? false : value;

        setValidationErrors({
            name: "",
            department: "",
            phone: "",
            email: "",
        });

        onChange({
            ...reporterInfo,
            reporter: {
                ...reporterInfo.reporter,
                [name]: updatedValue
            }
        });

        if (name === "name" && updatedValue.trim() === "") {
            setValidationErrors(prevErrors => ({...prevErrors, name: "Name is required"}));
        }

        if (name === "department" && updatedValue.trim() === "") {
            setValidationErrors(prevErrors => ({
                ...prevErrors,
                department: "Please enter the name of your department"
            }));
        }

        if (name === "phone") {
            if (updatedValue.trim() === "") {
                setValidationErrors(prevErrors => ({...prevErrors, phone: "Please enter the phone number"}));
            } else if (!phoneRegex.test(updatedValue)) {
                setValidationErrors(prevErrors => ({
                    ...prevErrors,
                    phone: "Please enter a valid phone number format with 6-14 digits, beginning with a plus sign"
                }));
            }
        }

        if (name === "email") {
            if (updatedValue.trim() === "") {
                setValidationErrors(prevErrors => ({...prevErrors, email: "Please enter your email address"}));
            } else if (!/\S+@\S+\.\S+/.test(updatedValue)) {
                setValidationErrors(prevErrors => ({...prevErrors, email: "Please enter a valid email address"}));
            }
        }
    };

    return (
        <div className="border bg-white rounded-md mb-4">
            <div onClick={toggleVisibility} className="flex flex-row justify-between items-center px-3 pt-3 border-b">
                <p className="text-2xl">Reporter Information</p>
                <IconButton className="pb-3">
                    <ExpandMoreIcon style={{transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)'}}/>
                </IconButton>
            </div>
            <Collapse in={isExpanded}>
                <Input
                    name="name"
                    label="Name"
                    className="mx-5 disabled"
                    placeholder="Enter your name"
                    required={true}
                    value={reporterInfo.reporter.name}
                    onChange={handleChange}
                    disabled={true}
                />
                {validationErrors.name && <Typography color="error">{validationErrors.name}</Typography>}

                <Input
                    name="department"
                    label="Department"
                    className="mx-5"
                    placeholder="Enter your department"
                    required={true}
                    value={reporterInfo.reporter.department}
                    onChange={handleChange}
                    disabled={true}
                />
                {validationErrors.department && <Typography color="error">{validationErrors.department}</Typography>}

                <Input
                    name="phone"
                    label="Phone"
                    className="mx-5"
                    placeholder="Enter your phone number"
                    required={true}
                    value={reporterInfo.reporter.phone}
                    onChange={handleChange}
                    disabled={true}
                />
                {validationErrors.phone && <Typography color="error">{validationErrors.phone}</Typography>}

                <Input
                    name="email"
                    label="Email"
                    className="mx-5 mb-3"
                    placeholder="Enter your email"
                    required={true}
                    value={reporterInfo.reporter.email}
                    onChange={handleChange}
                    disabled={true}
                />
                {validationErrors.email && <Typography color="error">{validationErrors.email}</Typography>}
            </Collapse>
        </div>
    );
}