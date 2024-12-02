import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import ManagerDetails from "./ManagerDetails.jsx";

export default function EmergencyResponse({ injuredPersonInfo, onChange }) {
    const handleChange = (e) => {
        const value = e.target.value === "Yes" ? true : e.target.value === "No" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                emergencyResponse: {
                    ...injuredPersonInfo.injuredPerson.emergencyResponse,
                    [e.target.name]: value
                }
            }
        });
    };



    return (
        <div>
            <div className="mx-5 my-3 border rounded-md shadow-md py-3">
                <p className="px-5 text-xl font-light">
                    Emergency Response Details
                </p>
                <Input
                    name="emergencyResponseOfficer"
                    label="Emergency Response Officer"
                    className="mx-5"
                    placeholder="Emergency Response Officer"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.emergencyResponse.emergencyResponseOfficer}
                />

                <Input
                    name="teamLeaderName"
                    label="Team Leader Name"
                    className="mx-5"
                    placeholder="Team Leader Name"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.emergencyResponse.teamLeaderName}
                />

                <CheckboxRadioGroup
                    name="bandagesUsed"
                    label="Are bandages used?"
                    className="mx-5"
                    type="radio"
                    options={["Yes", "No"]}
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.emergencyResponse.bandagesUsed ? "Yes" : "No"}
                />

                <CheckboxRadioGroup
                    name="extinguishersUsed"
                    label="Are extinguishers used?"
                    className="mx-5"
                    type="radio"
                    options={["Yes", "No"]}
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.emergencyResponse.extinguishersUsed ? "Yes" : "No"}
                />

                <CheckboxRadioGroup
                    name="callDetails"
                    label="Call details"
                    className="mx-5"
                    type="radio"
                    options={["Emergency number", "Personally called", "Personally addressed", "Detected by emergency response officer"]}
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.emergencyResponse.callDetails}
                />
            </div>
        </div>
    );
}
