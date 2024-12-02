import {useEffect, useState} from "react";
import {getTypeStatisticMonth} from "../../../Shared/API/statistics/getTypeStatisticMonth.jsx";
import PieChartSection from "../PieChartSection";
import {CircularProgress} from "@mui/material";

export default function PieChartTypesSection({period}){

    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    const periodQuery = period === "All Time" ? "allTime" : period === "1 Year" ? "year" : period === "1 Month" ? "month" : "week";


    useEffect(() => {
        setIsLoading(true);
        getTypeStatisticMonth(periodQuery)
            .then(response => {
                setData(response);
                setIsLoading(false);
            })
            .catch(error => {
                console.error('Error fetching pie:', error);
                setIsLoading(false);
            });
    }, [period]);


    return (
        <div>
            {isLoading ? (
                <CircularProgress />
            ) : (
                data && (
                    <div className="flex flex-col h-full">
                        <p className="text-2xl font-thin text-dark-blue ml-5 mt-3">Types</p>
                        <div className="flex-grow w-full mid:w-auto">
                            <PieChartSection data={data} />
                        </div>
                    </div>
                )
            )}
        </div>
    );
}