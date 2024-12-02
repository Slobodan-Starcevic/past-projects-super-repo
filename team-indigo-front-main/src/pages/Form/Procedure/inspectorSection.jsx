import Input from "../../../Shared/ui/Input.jsx";
import DatePicker from "../../../Shared/ui/DatePicker.jsx";
import { useState } from "react";
import { Typography } from "@mui/material";

export default function InspectorSection({ inspectorInfo, onChange }) {
  const [validationErrors, setValidationErrors] = useState({
    directorName: "",
    recipientName: "",
    date: "",
    time: "",
    caseNumber: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;

    // Reset validation errors on input change
    setValidationErrors((prevErrors) => ({
      ...prevErrors,
      [name]: value.trim() === "" ? `${name.charAt(0).toUpperCase() + name.slice(1)} is required` : "",
    }));

    onChange({
      ...inspectorInfo,
      procedure: {
        ...inspectorInfo.procedure,
        director: {
          ...inspectorInfo.procedure.director,
          [name]: value,
        },
      },
    });
  };

  return (
    <div className="">
      <div className="mx-5 my-3 border rounded-md shadow-md py-3">
        <p className="px-5 text-xl font-light">Prevention</p>

        <Input
            name="directorName"
            label="Director Name"
            className="mx-5"
            placeholder="Enter director name"
            required={true}
            onChange={handleChange}
            value={inspectorInfo.procedure.director.directorName}
        />
        {validationErrors.directorName && (
            <Typography color="error" className="mx-5">{validationErrors.directorName}</Typography>
        )}

        <Input
            name="recipientName"
            label="Recipient Name"
            className="mx-5"
            placeholder="Enter recipient name"
            required={true}
            onChange={handleChange}
            value={inspectorInfo.procedure.director.recipientName}
        />
        {validationErrors.recipientName && (
            <Typography color="error" className="mx-5">{validationErrors.recipientName}</Typography>
        )}

        <DatePicker
            name={"date"}
            type={"date"}
            className="mx-5"
            onChange={handleChange}
            value={inspectorInfo.procedure.director.date}
        />
        {validationErrors.date && (
            <Typography color="error" className="mx-5">{validationErrors.date}</Typography>
        )}

        <DatePicker
            name={"time"}
            type={"time"}
            className="mx-5"
            onChange={handleChange}
            value={inspectorInfo.procedure.director.time}
        />
        {validationErrors.time && (
            <Typography color="error" className="mx-5">{validationErrors.time}</Typography>
        )}

        <Input
            name="caseNumber"
            label="Case Number"
            className="mx-5"
            placeholder="Enter case number"
            required={true}
            onChange={handleChange}
            value={inspectorInfo.procedure.director.caseNumber}
        />
        {validationErrors.caseNumber && (
            <Typography color="error" className="mx-5">{validationErrors.caseNumber}</Typography>
        )}

      </div>
    </div>
  );
}
