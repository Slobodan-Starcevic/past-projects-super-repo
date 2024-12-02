import {useState} from "react";

import ReporterInformation from "../../Form/BasicInformation/ReporterInformation.jsx";
import TypeOfIncident from "../../Form/BasicInformation/TypeOfIncident.jsx";
import IncidentDetails from "../../Form/BasicInformation/IncidentDetails.jsx";
import InjuredPerson from "../../Form/InjuredPerson/InjuredPerson.jsx";
import DamageSection from "../../Form/DamageDetails/DamageSection.jsx";
import AdvancedDetailsSection from "../../Form/AdvancedDetails/AdvancedDetailsSection.jsx";
import ProcedureSection from "../../Form/Procedure/ProcedureSection.jsx";
import Button from "../../../Shared/ui/Button.jsx";
import Input from "../../../Shared/ui/Input.jsx";
import {postEditForm} from "../../../Shared/API/versions/postEditForm.jsx";
import {useMsal} from "@azure/msal-react";
import {createPopup} from "../../../Shared/popupHandler.js";

export default function EditForm({prevData, id, onEditComplete, closeEditForm}){

    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();

    const [data, setData] = useState(prevData)

    const handleReporterInfoChange = (newInfo) => {
        setData(newInfo);
    };

    const [request, setRequest] = useState({
        newForm: null,
        message: "",
        email: ""
    });

    const handleChange = (e) => {
        setRequest(prevState => ({
            ...prevState,
            message: e.target.value
        }));
    };


    const handlePost = async () => {
        await postEditForm({
            newForm: data,
            message: request.message,
            email: activeAccount.username
        }, id)
            .then(response =>{
                createPopup("success", "Form changed")
                onEditComplete();
                closeEditForm();
            })
    };

    return (
        <div className="flex flex-column items-center justify-center">
            <div className="report-container w-[80%] bg-gray-100 border mt-5 rounded-md p-5" style={{ maxHeight: '800px', overflowY: 'auto' }}>
                <ReporterInformation reporterInfo={data} onChange={handleReporterInfoChange} />
                <TypeOfIncident typeOfIncidentInfo={data} onChange={handleReporterInfoChange} />
                <IncidentDetails reporterInfo={data} onChange={handleReporterInfoChange} />
                { data.incident.typeOfIncident.includes("Personal Injury") ?
                    <InjuredPerson injuredPersonInfo={data} onChange={handleReporterInfoChange}/>
                    :
                    null
                }
                { data.incident.typeOfIncident.includes("Damage") ?
                    <DamageSection damageInfo={data} onChange={handleReporterInfoChange}/>
                    :
                    null
                }
                <AdvancedDetailsSection advancedInfo={data} onChange={handleReporterInfoChange} />
                <ProcedureSection procedureInfo={data} onChange={handleReporterInfoChange} />

                <div className="w-100 flex flex-column items-center justify-center border bg-white rounded-md mb-4 py-5 ">
                    <Input
                        name="Commit message"
                        label="Name"
                        className="mx-5 w-[80%]"
                        placeholder="Enter message"
                        onChange={handleChange}
                        value={request.message}
                    />
                </div>

                <div className="w-100 flex justify-center">
                    <Button className="w-[40%] rounded-sm mt-4" onClick={handlePost} text="Edit Form" />
                </div>
            </div>
        </div>
    );
}