import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";
import ManagerDetails from "./ManagerDetails.jsx";

export default function Hospital({ injuredPersonInfo, onChange }) {
    const handleChange = (e) => {
        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                hospital: {
                    ...injuredPersonInfo.injuredPerson.hospital,
                    [e.target.name]: value
                }
            }
        });
    };



    return (
        <div>
            <div className="mx-5 my-3 border rounded-md shadow-md py-3">
                <p className="px-5 text-xl font-light">
                    Hospital Details
                </p>
                <Input
                    name="name"
                    label="Hospital Name"
                    className="mx-5"
                    placeholder="Enter name"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.hospital.name}
                />
                <Input
                    name="section"
                    label="Hospital Section"
                    className="mx-5"
                    placeholder="Enter Section"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.hospital.section}
                />
                <Input
                    name="details"
                    label="Hospital Details"
                    className="mx-5"
                    placeholder="Enter Details"
                    onChange={handleChange}
                    value={injuredPersonInfo.injuredPerson.hospital.details}
                />
            </div>
        </div>
    );
}
