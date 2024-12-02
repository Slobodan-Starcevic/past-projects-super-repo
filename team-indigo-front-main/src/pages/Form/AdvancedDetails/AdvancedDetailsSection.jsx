import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import Input from "../../../Shared/ui/Input.jsx";
import { useState } from "react";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";
import { Collapse, IconButton, Typography } from "@mui/material";

export default function AdvancedDetailsSection({ advancedInfo, onChange }) {
  const [isExpanded, setIsExpanded] = useState(true);

  const toggleVisibility = () => {
    setIsExpanded(!isExpanded);
  };


  

  // Validation logic
  const [validationErrors, setValidationErrors] = useState({
    explanation: "",
    reoccurrence: "",
  });

  const handleChange = (e) => {
    const { name, value, checked, type } = e.target;

    setValidationErrors({
      explanation: "",
      reoccurrence: "",
    });

    if (type === "checkbox") {
      const updatedValues = checked
        ? [...(advancedInfo.advancedDetails[name] || []), value]
        : advancedInfo.advancedDetails[name].filter(
            (type) => type !== value
          );

      onChange({
        ...advancedInfo,
        advancedDetails: {
          ...advancedInfo.advancedDetails,
          [name]: updatedValues,
        },
      });
    } else {
      onChange({
        ...advancedInfo,
        advancedDetails: {
          ...advancedInfo.advancedDetails,
          [name]: value,
        },
      });

      // Validation checks
      if (name === "explanation" && value.trim() === "") {
        setValidationErrors({
          ...validationErrors,
          explanation: "Explanation is required",
        });
      }

      if (name === "reoccurrence" && value.trim() === "" ) {
        setValidationErrors({
          ...validationErrors,
          reoccurrence: "Chance of reoccurence is required",
        });
      }
    }
  };

  const circumstancesOptions = [
    "Insufficiently secured tools",
    "Insufficiently secure work location",
    "Defect in machine or installation",
    "Unsafe construction",
    "Hazardous installation/set-up",
    "Inadequate lighting",
    "Inadequate ventilation",
    "Unsafe clothing",
    "Lack of organization and cleanliness",
    "Too much ambient noise",
    "Incorrect labeling/packaging",
  ];

  const actionsOptions = [
    "Not authorized to operate",
    "Work carried out without protective equipment",
    "Protections disabled",
    "Used incorrect tools",
    "Unsafe usage of tools",
    "Unsafe loading, stowage, or stacking",
    "Taking an unsafe place or posture",
    "Working on hazardous materials",
    "Distracting, teasing, frolicking",
    "Incorrect working method",
  ];

  const organizationOptions = [
    "Insufficient instructions",
    "Insufficient qualified person",
    "Failure to provide work preparation",
    "Insufficient maintenance of equipment",
    "Insufficient consultation / coordination",
    "Incomplete materials or equipment",
    "Failure to provide capacity",
  ];

  const severityOptions = [
    "No damage",
    "Injury without default",
    "Injury with absence",
    "Environmental damage",
    "Material damage",
    "Deployment of ambulance",
    "Deployment of fire brigade",
    "Deployment of police",
  ];


  return (
    <div className="border bg-white rounded-md mb-4">
      <div
        onClick={toggleVisibility}
        className="flex flex-row justify-between items-center px-3 pt-3 border-b "
      >
        <p className="text-2xl">Advance Details Information</p>
        <IconButton className="pb-3">
          <ExpandMoreIcon
            style={{ transform: isExpanded ? "rotate(180deg)" : "rotate(0deg)" }}
          />
        </IconButton>
      </div>
      <Collapse in={isExpanded} className="mx-5">
        <CheckboxRadioGroup
            name={"circumstances"}
            label={"Circumstances"}
            type={'checkbox'}
            options={circumstancesOptions}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.circumstances}
        />

        <CheckboxRadioGroup
            name={"actions"}
            label={"Actions"}
            type={'checkbox'}
            options={actionsOptions}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.actions}
        />

        <CheckboxRadioGroup
            name={"organization"}
            label={"Organization"}
            type={'checkbox'}
            options={organizationOptions}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.organization}
        />

        <Input
            name="explanation"
            label="Explanation"
            className=""
            placeholder="Explain what happened in details"
            required={true}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.explanation}
        />

        <Input
            name="reoccurrence"
            label="Chance of reoccurrence?"
            className=""
            placeholder="Estimate chance of reoccurrence?"
            required={true}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.reoccurrence}
        />

        <CheckboxRadioGroup
            name={"severity"}
            label={"Severity of incident"}
            type={'checkbox'}
            className="mb-3"
            options={severityOptions}
            onChange={handleChange}
            value={advancedInfo.advancedDetails.severity}
        />

      </Collapse>
    </div>
  );
}
