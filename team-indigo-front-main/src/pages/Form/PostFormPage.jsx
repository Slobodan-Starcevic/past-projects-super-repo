import ReporterInformation from "./BasicInformation/ReporterInformation.jsx";
import React, {useState} from "react";
import TypeOfIncident from "./BasicInformation/TypeOfIncident.jsx";
import IncidentDetails from "./BasicInformation/IncidentDetails.jsx";
import InjuredPerson from "./InjuredPerson/InjuredPerson.jsx";
import AdvancedDetailsSection from "./AdvancedDetails/AdvancedDetailsSection.jsx";
import ProcedureSection from "./Procedure/ProcedureSection.jsx";
import DamageSection from "./DamageDetails/DamageSection.jsx";
import Button from "../../Shared/ui/Button.jsx";
import {postFormFull} from "../../Shared/API/postForm.jsx";
import AproveFormPost from "./AproveFormPost";
import {IconButton} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close.js";
import Popup from "../Dashboard/components/Popup.jsx";
import { useMsal } from "@azure/msal-react";

export default function PostFormPage(){
    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();
    const name = activeAccount.idTokenClaims.name;
    const deparment = activeAccount.idTokenClaims.family_name;
    const phone = activeAccount.idTokenClaims.given_name;
    const email = activeAccount.idTokenClaims.email;

    const [data, setData] = useState({

        //Reporter info
        reporter:{
            name: name, //text
            department: deparment, //text
            phone: phone, //phone
            email: email //email
        },

        //Incident details
        incident:{
            typeOfIncident: [], //array text

            date: '', //date
            time: '', //time
            location: '', //text

            workHours: '', //bool
            whileWorking: '', //bool

            description: '', //text
            environment: '' //text
        },

        //Injured person details

        injuredPerson: {
            name: '', //text
            department: '', //text
            phone: '', //phone
            email: '', //email
            position: '', //text

            supervisor: {
                name: '', //text
                phone: '', //phone
                informed: '' //bool
            },
            goTo: '', //text
            aande: {
                name: '', //text
                section: '', //text
                details: '', //text
            },
            hospital: {
                name: '', //text
                section: '', //text
                details: '' //text
            },
            gpDetails: {
                name: '', //text
                section: '', //text
                details: '' //text
            },
            emergencyResponse: {
                emergencyResponseOfficer: '', //text
                teamLeaderName: '', //text
                bandagesUsed: '', //bool
                extinguishersUsed: '', //bool
                callDetails: '' //text
            },
        },

        //Injured person details

        damage: {
            description: '' //text
        },

        //Advanced details

        advancedDetails: {
            circumstances: [], //array text
            actions: [], //array text
            organization: [], //array text
            explanation: '', //text
            reoccurrence: '', //text
            severity: [], //array text
        },

        //Procedure details

        procedure: {
            isprocedure: null, //bool
            procedureFollowed: '', //bool
            personFamiliar: '', //bool
            howLikely: '', //text
            prevention: {
                prevent: '', //text
                causes: '', //text
                futureChanges: '' //text
            },

            reportHR: '', //bool
            director: {
                directorName : '',  //text
                recipientName : '',  //text
                date: '',  //date
                time: '', //time
                caseNumber: '', //text
            }
        }

    });

    console.log(data)

    const handleReporterInfoChange = (newInfo) => {
        setData(newInfo);
    };

    const [message, setMessage] = useState(null);

    const [aprove, setAprove] = useState(false);

    const handlePopup = () =>{
        setAprove(!aprove)
    }

    const handlePost = async () => {
        setAprove(true)
    };

    const onClose = () => {
        setAprove(false)
    }

    return (
        <div className="flex flex-column items-center justify-center">
            {aprove &&
                <div className='fixed inset-0 z-10 flex justify-center items-center'>
                    <div onClick={handlePopup} className='flex flex-col w-full h-full zero:bg-white mid:bg-black mid:bg-opacity-50'>
                        <div className="flex justify-end mr-5 mt-1">
                            <IconButton
                                className="z-20"
                                style={{ color: 'black' }}
                                onClick={handlePopup}>
                                <CloseIcon />
                            </IconButton>
                        </div>
                    </div>
                    <AproveFormPost data={data} onClose={onClose}/>
                </div>
            }
            <div className="w-[80%] bg-gray-100 border mt-5 rounded-md p-5">
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
            </div>
            { message ?
                <div className="p-5 rounded-sm border-1">
                    {message}
                </div>
                :
                null
            }
            <Button className="w-[40%] rounded-sm mt-4" onClick={handlePost} text="Submit Form" />
        </div>
    );
}