import Input from "../../../Shared/ui/Input.jsx";
import CheckboxRadioGroup from "../../../Shared/ui/CheckboxRadioGroup.jsx";

export default function ManagerDetails({ injuredPersonInfo, onChange }) {

    const handleChange = (e) => {
        const value = e.target.value === "yes" ? true : e.target.value === "no" ? false : e.target.value;
        onChange({
            ...injuredPersonInfo,
            injuredPerson: {
                ...injuredPersonInfo.injuredPerson,
                supervisor: {
                    ...injuredPersonInfo.injuredPerson.supervisor,
                    [e.target.name]: value
                }
            }
        });
    };

    return(
        <div className="mx-5 my-3 border rounded-md shadow-md py-3">
            <p className="px-5 text-xl font-light">
                Manager Details
            </p>
            <Input
                name="name"
                label="Manager Name"
                className="mx-5"
                placeholder="Name of Manager"
                onChange={handleChange}
                value={injuredPersonInfo.injuredPerson.supervisor.name}
            />
            <Input
                name="phone"
                label="Manager Phone"
                className="mx-5"
                placeholder="Phone Number"
                onChange={handleChange}
                value={injuredPersonInfo.injuredPerson.supervisor.phone}
            />
            <CheckboxRadioGroup
                name="informed"
                label="Is supervisor informed?"
                className="mx-5"
                type="radio"
                options={["yes", "no"]}
                onChange={handleChange}
                value={injuredPersonInfo.injuredPerson.supervisor.informed ? "yes" : "no"}
            />
        </div>
    )
}