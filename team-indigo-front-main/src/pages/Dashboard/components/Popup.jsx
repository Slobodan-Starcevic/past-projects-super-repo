import React, {memo, useEffect, useState} from 'react'
import {getFormFull} from "../../../Shared/API/getFormFull.jsx";
import {Box, Button, CircularProgress, IconButton} from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import ReportDisplay from "./ReportDisplay.jsx";
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import {putCompleteAppointment} from "../../../Shared/API/putCompleteAppointment.jsx";
import TodoMenu from "./TodoMenu.jsx";
import MainDataReportHeader from "./MainDataReportHeader.jsx";
import VersionMenu from "./VersionMenu";
import {getVersions} from "../../../Shared/API/versions/getVersions.jsx";
import {getVersion} from "../../../Shared/API/versions/getVersion.jsx";
import EditForm from "./EditForm";
import {createPopup} from "../../../Shared/popupHandler.js";
import {useNavigate} from "react-router-dom";
import {putDeleteForm} from "../../../Shared/API/putDeleteForm.jsx";
import {useMsal} from "@azure/msal-react";


function Popup({id, handleUpdate, closePopup}) {

    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();
    const isAuthorized = (activeAccount.idTokenClaims.roles[0] !== "regular_staff");

  const [data, setData] = useState(null);

  const [versions, setVersions] = useState(1);

  const [refresh, setRefresh] = useState(false)

  const [selectedVersion, setSelectedVersion] = useState("latest");


  const [versionMessage, setVersionMessage] = useState({
      version: null,
      message: null,
      employeeName: null,
      dateTime: null
  })


    useEffect(() => {
        console.log("refresh all")
        getVersions(id)
            .then(response => {
                setVersions(response);
            }).catch(error => {
            console.error('Failed to load versions:', error);
        })
    }, [refresh])

  const handleComplete = () => {
    putCompleteAppointment(id)
        .then(response => {
            setData({ ...data, status: 'complete' });
            handleUpdate();
            createPopup("success", "Form completed")
        }).catch(error => {
         createPopup("error", "Error completing Form")
        closePopup()
    });
  }


    const [versionAnchorEl, setVersionAnchorEl] = useState(null);
    const [todoAnchorEl, setTodoAnchorEl] = useState(null);



    const handleMenuClick = (event, menuType) => {
        if (menuType === 'version') {
            setVersionAnchorEl(event.currentTarget);
        } else if (menuType === 'todo') {
            setTodoAnchorEl(event.currentTarget);
        }
    };

    const closeEditMode = () => {
        setIsEditMode(false)
    }

    const handleClose = () => {
        setVersionAnchorEl(null);
        setTodoAnchorEl(null);
    };

    const [isEditMode, setIsEditMode] = useState(false);

    const handleEdit = () => {
        setIsEditMode(true)
        handleClose();
    };

    const handleDelete = () => {
        putDeleteForm(id)
            .then(response => {
                handleUpdate();
                createPopup("success", "Form deleted")
            }).catch(error => {
            createPopup("error", "Error deleting form")
            console.error('Error fetching doctors:', error);
        });
        closePopup();
        handleClose();
    };

    const onEditComplete = () => {
        setRefresh(!refresh);
    };

    const handleSelect = (version) =>{
        getVersion(id, version)
            .then(response => {
                setData({ ...data, data: response.data });
                setVersionMessage({
                    version: response.version,
                    message: response.message,
                    employeeName: response.employeeName,
                    dateTime: response.dateTime
                })
                setSelectedVersion(version);
            })
            .catch(error => {
                console.error('Error fetching version data:', error);
            });
    }

  useEffect(() => {
      console.log("refresh version")
    getFormFull(id)
        .then(response => {
          setData(response)
        })
        .catch(error => {
          console.error('Error fetching doctors:', error);
        });
  }, [id, refresh]);

    return (
        <div className='flex flex-row absolute bg-blue-dark w-full mid:w-[1000px] h-[90%] rounded-[2px] overflow-hidden z-3 rounded-md'>
            <div className={`flex flex-col mid:flex-row bg-white rounded-md overflow-auto z-3 w-full`}>
                {isEditMode && (
                    <div className="w-100 h-100 absolute bg-white z-3">
                        <EditForm prevData={data.data} id={id} onEditComplete={onEditComplete} closeEditForm={closeEditMode}/>
                        <div
                            onClick={()=>setIsEditMode(false)}
                            className="absolute top-0 p-3 right-0">
                            <CloseIcon />
                        </div>
                    </div>
                )}
                {data ? (
                    <>
                        <div className="mid:w-[30vw] p-4">
                            <div className="font-thin text-xl mt-2">Version Details:</div>
                            {selectedVersion !== "latest" ? (
                                <Box
                                    sx={{
                                        backgroundColor: 'rgba(248,251,255,0.8)',
                                        padding: 2,
                                        marginY: 2,
                                        border: '1px solid #ddd',
                                        borderRadius: 1,
                                        marginBottom: 2,
                                        boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.1)'
                                    }}
                                >
                                    Version: {versionMessage.version}<br />
                                    Message: {versionMessage.message}<br />
                                    Employee Name: {versionMessage.employeeName}<br />
                                    Date/Time: {versionMessage.dateTime}
                                </Box>
                            )
                            :
                                <MainDataReportHeader data={data} />}
                        </div>
                        <div className="w-full mid:w-[70vw] p-4">
                            <div className="flex flex-row justify-between items-center mb-3">
                                <div className="flex items-center">
                                    <div>
                                        Version
                                    </div>
                                    <IconButton onClick={(e) => handleMenuClick(e, 'version')}><KeyboardArrowDownIcon /></IconButton>
                                    <VersionMenu
                                        anchorEl={versionAnchorEl}
                                        handleClose={handleClose}
                                        handleSelect={handleSelect}
                                        versions={versions}
                                    />
                                </div>
                                <div className="flex items-center">
                                    {isAuthorized && data && data.status !== "complete" && (
                                        <Button onClick={handleComplete} sx={{ color: 'green', '&:hover': { backgroundColor: '#e8f5e9' } }}>
                                            Complete
                                        </Button>
                                    )}
                                    {!isAuthorized && data && data.status === "complete" && (
                                        <Button onClick={handleEdit} sx={{ color: 'blue', '&:hover': { backgroundColor: '#e3f2fd' } }}>
                                            Edit
                                        </Button>
                                    )}
                                    <IconButton onClick={(e) => handleMenuClick(e, 'todo')}><KeyboardArrowDownIcon /></IconButton>
                                    <TodoMenu
                                        anchorEl={todoAnchorEl}
                                        handleClose={handleClose}
                                        handleEdit={handleEdit}
                                        handleDelete={handleDelete}
                                        status={data ? data.status : null}
                                    />
                                </div>
                            </div>
                            <div className="h-[95%]">
                                <ReportDisplay reportData={data.data}/>
                            </div>
                        </div>
                    </>
                ) : (
                    <CircularProgress/>
                )}
            </div>
        </div>
    );
}



export default memo(Popup)