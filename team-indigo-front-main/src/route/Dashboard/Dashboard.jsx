import React, { useState, useEffect } from 'react';

import formAPI from '../../Shared/API/formAPI.js';
import PaginationComponent from '../../Shared/ui/PaginationComponent';
import {getFormsList} from "../../Shared/API/getFormsList.jsx";
import {useLocation} from "react-router-dom";
import ReportBar from "./components/ReportBar.jsx";
import Popup from "./components/Popup.jsx";
import FilterButton from "./components/FilterButton.jsx";
import {getFormFull} from "../../Shared/API/getFormFull.jsx";
import {formatDateString} from "../../Shared/utility/calculateDate.jsx";

function Dashboard() {

  const [loadedPages, setLoadedPages] = useState([]);

  const [popUp, setPopUp] = useState(false);
  const [form, setForm] = useState({});
  const [forms, setForms] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);

  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);


  useEffect(() => {
    getFormsList(queryParams)
        .then(response => {
          if (!loadedPages.includes(response.currentPage)) {
              setForms(prevForms => [...prevForms, ...response.reports]);
              setLoadedPages(prevPages => [...prevPages, response.currentPage]);
          }
          setTotalPages(response.totalPage)
        })
        .catch(error => {
          console.error('Error fetching doctors:', error);
        });
  }, [currentPage]);


    const handleChoice = (incident) =>{
        getFormFull(incident.id)
            .then(response => {
                setForm(response)
            })
            .catch(error => {
                console.error('Error fetching doctors:', error);
            });
        setPopUp(!popUp);
    };
    const handlePopup = ()=>{
        setPopUp(!popUp);
    };

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };

  return (
      <div className="relative flex flex-column items-center h-[100vh]">
        {popUp &&
            <div className='fixed inset-0 flex justify-center items-center'>
              <div onClick={()=>handlePopup()} className='absolute w-full h-full bg-black opacity-50'></div>
              <Popup data={form}/>
            </div>
        }
        {forms.length > 0 ?
            <div className="w-[80%] bg-white border mt-5 rounded-md p-5">
                <div className='w-full bg-white flex border-b-2 border-gray-500 font-light pb-2 font-bold'>
                    <div className="w-[10%] pl-4">Id</div>
                    <div className="w-[20%]">Reporter</div>
                    <div className="w-[20%]">Type</div>
                    <div className="w-[15%]">Severity</div>
                    <div className="w-[15%]">Date</div>
                    <div className="w-[15%]">Status</div>
                </div>
                <table className="w-full">
                    <tbody>
                    {forms.map((incident) => (
                                <ReportBar
                                    key={incident.id}
                                    onClick={() => handleChoice(incident)}
                                    incidentId={incident.id}
                                    reporter={incident.employeeName}
                                    incidentType={incident.type}
                                    IncidentSeverity={incident.severity}
                                    date={formatDateString(incident.dateTime)}
                                    status={incident.status}/>
                            ))}
                    </tbody>
                </table>
            </div>
            :
            <div>
              loading
            </div>
        }
        <div className="flex justify-center">
            {!popUp ?
                <PaginationComponent
                    currentPage={currentPage}
                    totalPages={totalPages}
                    onPageChange={handlePageChange} // Make sure this function is defined
                    baseUrl=""
                />
                :
                null
            }
        </div>
      </div>
  );
}

export default Dashboard;
