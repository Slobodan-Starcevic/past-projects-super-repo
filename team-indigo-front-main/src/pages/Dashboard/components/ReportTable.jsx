import Popup from "./Popup.jsx";
import FilterButton from "./FilterButton.jsx";
import ReportBar from "./ReportBar.jsx";
import {CircularProgress, IconButton, Pagination} from "@mui/material";
import React, {useState} from "react";
import CloseIcon from '@mui/icons-material/Close';

export default function ReportTable({reports, filters, totalPages, currentPage, handlePageChange, handleFilterChange, handleUpdate}) {

    const [popUp, setPopUp] = useState(false);
    const [selectedId, setSelectedId] = useState(null);


    const closePopup = () => {
        setPopUp(false)
    }


    const handleChoice = (incident) =>{
        setSelectedId(incident.id);
        setPopUp(!popUp);
    };
    const handlePopup = ()=>{
        setPopUp(!popUp);
    };

    return(
        <>        
        <div className="w-full h-[100vh]">
            {popUp &&
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
                    <Popup id={selectedId} handleUpdate={handleUpdate} closePopup={closePopup}/>
                </div>
            }

            <div className="w-full mid:w-[80%] mx-auto bg-white border mt-[20vh] rounded-md p-2 mid:p-5">
                <div className='flex flex-row overflow-auto'>
                    <FilterButton name="ID" width="10%" onFilterSelect={handleFilterChange}/>
                    <FilterButton name="Reporter" width="15%"   filterOptions={filters.reporterCounts}      onFilterSelect={handleFilterChange}/>
                    <FilterButton name="Type" width="20%"       filterOptions={filters.incidentTypeCounts}  onFilterSelect={handleFilterChange}/>
                    <FilterButton name="Severity" width="15%"   filterOptions={filters.severityCounts}      onFilterSelect={handleFilterChange}/>
                    <FilterButton name="Date" width="20%"       filterOptions={filters.dateCounts}          onFilterSelect={handleFilterChange}/>
                    <FilterButton name="Status" width="15%"     filterOptions={filters.statusCounts}        onFilterSelect={handleFilterChange}/>
                </div>

                {reports ? (
                    <div className="overflow-x-auto">
                        <table className="min-w-full">
                        <tbody>
                        {reports.map((incident) => (
                            <ReportBar
                                key={incident.id}
                                onClick={() => handleChoice(incident)}
                                incidentId={incident.id}
                                reporter={incident.employeeName}
                                incidentType={incident.type.join(', ')}
                                IncidentSeverity={incident.severity}
                                date={incident.date}
                                status={incident.status}/>
                        ))}
                        </tbody>
                        </table>
                    </div>
                ): (<div className="my-5">
                        <CircularProgress/>
                    </div>)}

                {!popUp && (
                    <Pagination
                        count={totalPages}
                        page={currentPage + 1}
                        onChange={(event, page) => handlePageChange(event, page)}
                        color="primary"
                        showFirstButton
                        showLastButton
                        className="my-4"
                    />
                )}
            </div>  
        </div>
    </>
    )
}