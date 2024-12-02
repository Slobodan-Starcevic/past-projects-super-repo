
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import PreventionSection from "./PreventionSection.jsx";
import InspectorSection from "./inspectorSection.jsx";
import {Collapse, IconButton} from "@mui/material";
import {useState} from "react";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore.js";

export default function ProcedureSection({ procedureInfo, onChange }) {
    const handleChange = (e) => {
        const updatedValue = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...procedureInfo,
            procedure: {
                ...procedureInfo.procedure,
                [e.target.name]: updatedValue
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
                    Procedure
                </p>
                <IconButton className="pb-3">
                    <ExpandMoreIcon style={{ transform: isExpanded ? 'rotate(180deg)' : 'rotate(0deg)'}} />
                </IconButton>
            </div>
            <Collapse in={isExpanded}>
                <CheckboxRadioGroup
                    name="isprocedure"
                    label="Is there a procedure for the actions that took place?"
                    className="mx-5"
                    type="radio"
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={procedureInfo.procedure.isprocedure === true ? "yes" : procedureInfo.procedure.isprocedure === false ? "no" : ''}
                />

                <CheckboxRadioGroup
                    name="procedureFollowed"
                    label="Was that procedure followed?"
                    className="mx-5"
                    type="radio"
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={procedureInfo.procedure.procedureFollowed === true ? "yes" : procedureInfo.procedure.procedureFollowed === false ? "no" : ''}
                />

                <CheckboxRadioGroup
                    name="personFamiliar"
                    label="Was the person affected familiar with this procedure?"
                    className="mx-5"
                    type="radio"
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={procedureInfo.procedure.personFamiliar === true ? "yes" : procedureInfo.procedure.personFamiliar === false ? "no" : ''}
                />

                <CheckboxRadioGroup
                    name="howLikely"
                    label="In your opinion, how likely do you think this is to reoccur?"
                    className="mx-5"
                    type="radio"
                    options={["Very likely", "Likely", "Unsure", "Unlikely", "Very unlikely"]}
                    onChange={handleChange}
                    value={procedureInfo.procedure.howLikely}
                />

                <CheckboxRadioGroup
                    name="reportHR"
                    label="Did you report the labor inspection via HR?"
                    className="mx-5"
                    type="radio"
                    options={["yes", "no"]}
                    onChange={handleChange}
                    value={procedureInfo.procedure.reportHR === true ? "yes" : procedureInfo.procedure.reportHR === false ? "no" : ''}
                />

                { procedureInfo.procedure.reportHR === true ?
                    <InspectorSection inspectorInfo={procedureInfo} onChange={onChange} />
                    :
                    null
                }
            </Collapse>
        </div>
    );
}
