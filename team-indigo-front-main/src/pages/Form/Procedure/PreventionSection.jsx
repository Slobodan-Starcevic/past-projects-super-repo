import Input from "../../../Shared/ui/Input.jsx";
import { useState } from "react";

export default function PreventionSection({ preventionInfo, onChange }) {
  const [validationErrors, setValidationErrors] = useState({
    prevent: "",
    causes: "",
    futureChanges: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;

    // Reset validation errors on input change
    setValidationErrors((prevErrors) => ({
      ...prevErrors,
      [name]: "",
    }));

    onChange({
      ...preventionInfo,
      procedure: {
        ...preventionInfo.procedure,
        prevention: {
          ...preventionInfo.procedure.prevention,
          [name]: value,
        },
      },
    });

    // Validation checks
    if (name === "prevent" && value.trim() === "") {
      setValidationErrors((prevErrors) => ({
        ...prevErrors,
        prevent: "Prevention is required",
      }));
    }

    if (name === "causes" && value.trim() === "") {
      setValidationErrors((prevErrors) => ({
        ...prevErrors,
        causes: "Causes is required",
      }));
    }

    if (name === "futureChanges" && value.trim() === "") {
      setValidationErrors((prevErrors) => ({
        ...prevErrors,
        futureChanges: "Future Changes is required",
      }));
    }
  };

  return (
    <div className="">
      <div className="mx-5 my-3 border rounded-md shadow-md py-3">
        <p className="px-5 text-xl font-light">Prevention</p>

        <Input
          name="prevent"
          label="What do you believe could have prevented this incident?"
          className="mx-5"
          placeholder="What could have prevented incident?"
          onChange={handleChange}
        />
        {validationErrors.prevent && (
          <div style={{ color: 'red' }}>{validationErrors.prevent}</div>
        )}

        <Input
          name="causes"
          label="What are your expectations for follow-up or future changes because of this occurrence?"
          className="mx-5"
          placeholder="What were the underlying causes?"
          onChange={handleChange}
        />
        {validationErrors.causes && (
          <div style={{ color: 'red' }}>{validationErrors.causes}</div>
        )}

        <Input
          name="futureChanges"
          label="In your opinion, what were the underlying causes that contributed to this incident?"
          className="mx-5"
          placeholder="What are your expectations?"
          onChange={handleChange}
        />
        {validationErrors.futureChanges && (
          <div style={{ color: 'red' }}>{validationErrors.futureChanges}</div>
        )}
      </div>
    </div>
  );
}
