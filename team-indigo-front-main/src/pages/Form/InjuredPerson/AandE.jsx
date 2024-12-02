import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import ManagerDetails from "./ManagerDetails.jsx";

export default function AandE({ injuredPersonInfo, onChange }) {
    const handleChange = (e) => {
        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                aande: {
                    ...injuredPersonInfo.injuredPerson.aande,
                    [e.target.name]: value
                }
            }
        });
    };



    return (
        <div>
            <div className="mx-5 my-3 border rounded-md shadow-md py-3">
                <p className="px-5 text-xl font-light">
                    A&E Details
                </p>
                <Input
                    name="name"
                    label="Name"
                    className="mx-5"
                    placeholder="Name"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.aande.name}
                />
                <Input
                    name="section"
                    label="Section"
                    className="mx-5"
                    placeholder="Section"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.aande.section}
                />
                <Input
                    name="details"
                    label="Details"
                    className="mx-5"
                    placeholder="Details"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.aande.details}
                />
            </div>
        </div>
    );
}
