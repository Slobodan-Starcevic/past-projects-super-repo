import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import ManagerDetails from "./ManagerDetails.jsx";

export default function GPDetails({ injuredPersonInfo, onChange }) {
    const handleChange = (e) => {
        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                gpDetails: {
                    ...injuredPersonInfo.injuredPerson.gpDetails,
                    [e.target.name]: value
                }
            }
        });
    };



    return (
        <div>
            <div className="mx-5 my-3 border rounded-md shadow-md py-3">
                <p className="px-5 text-xl font-light">
                    GP Details
                </p>
                <Input
                    name="name"
                    label="Name"
                    className="mx-5"
                    placeholder="Enter Name"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.gpDetails.name}
                />
                <Input
                    name="section"
                    label="Section"
                    className="mx-5"
                    placeholder="Enter Section"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.gpDetails.section}
                />
                <Input
                    name="details"
                    label="Details"
                    className="mx-5"
                    placeholder="Enter Details"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.gpDetails.details}
                />
            </div>
        </div>
    );
}
