import React, {useEffect} from 'react';
import { useState } from 'react';
import { getAllReports  } from "../../Shared/API/getAllReports.jsx";
import { createPopup } from '../../Shared/popupHandler.js';
import CloseIcon from '@mui/icons-material/Close';
import Forms from './Forms.jsx';
import FilterBar from './FilterBar.jsx';
import {IconButton, Pagination} from '@mui/material';
import Popup from './components/Popup.jsx';
import { useMsal } from "@azure/msal-react";


export default function Dashboard() {
    const [update, setUpdate] = useState(false);
    const [popUp, setPopUp] = useState(false);
    const [selectedId, setSelectedId] = useState(null);
    const [formsData, setFormsData] = useState([]);
    const [filterData, setFilterData] = useState({});
    const [paginationData, setPaginationData] = useState({
        currentPage: 1,
        totalPages: 1,
        totalItems: null,
        pageSize: 10
    });
    const [chosenFilters, setChosenFilters] = useState({
        id: null,
        reporter: null,
        type: null,
        severity: null,
        building: null,
        date: null,
        status: null
    });
    const { instance } = useMsal();
    const activeAccount = instance.getActiveAccount();
    const role = activeAccount.idTokenClaims.roles[0];
    const name = activeAccount.idTokenClaims.name;

    useEffect(() => {
        console.log(chosenFilters)
    }, [chosenFilters])

    useEffect(() => {
        const fetchData = async () => {
            try {
                const params = {
                    ...chosenFilters,
                    currentPage: paginationData.currentPage - 1,
                    pageSize: 10
                }

                const response = await getAllReports(params, role, name);

                if (response) {
                    setFormsData(response.reports);
                    setPaginationData({
                        currentPage: response.currentPage + 1,
                        totalPages: response.totalPage,
                        totalItems: response.totalElements
                    });
                    setFilterData(response.filterCounts);
                }
            } catch (error) {
                console.error('Error fetching reports:', error);
                createPopup("error", error.message);
            }
        };

        fetchData();
    }, [paginationData.currentPage, chosenFilters, update]);

    const handleUpdate = () => {
        setUpdate(!update);
    }

    const handlePageClick = (event, value) => {
        setPaginationData((prevPaginationData) => ({
            ...prevPaginationData,
            currentPage: value,
        }));
    };

    const handleFilterChange = (category, chosenFilter) => {
        setChosenFilters((prevChosenFilter) => ({
            ...prevChosenFilter,
            [category]: chosenFilter,
        }));
    };

    const closePopup = () => {
        setPopUp(false);
    };

    const handleChoice = (incident) => {
        setSelectedId(incident.id);
        setPopUp(!popUp);
    };

    const handlePopup = () => {
        setPopUp(!popUp);
    };
    
  return(
    <>
        <div className="w-full flex justify-center p-4">
            <div className="w-full max-w-5xl">
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

                <FilterBar filterData={filterData} handleFilterChange={handleFilterChange}/>

                {formsData.length != 0 ?
                    <Forms forms={formsData} handleChoice={handleChoice}/>
                    :
                    null
                }


                <div className='flex justify-center'>
                    <Pagination
                    count={paginationData.totalPages}
                    page={paginationData.currentPage}
                    boundaryCount={1}
                    color='primary'
                    size='large'
                    onChange={handlePageClick}
                    />
                </div>
            </div>
        </div>
    </>
  )
}

