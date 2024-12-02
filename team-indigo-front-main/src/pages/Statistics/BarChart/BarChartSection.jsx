import IncidentBarChart from "./IncidentBarChart.jsx";
import { useEffect, useState } from "react";
import { getCalendarStatisticsMonth } from "../../../Shared/API/statistics/getCalendarStatisticsMonth.jsx";
import { transformDataGraph } from "../../../Shared/utility/transformData.jsx";
import { CircularProgress } from "@mui/material";

export default function BarChartSection({ period }) {
    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [isEmpty, setIsEmpty] = useState(false);

    const periodQuery = period === "All Time" ? "allTime" : period === "1 Year" ? "year" : period === "1 Month" ? "month" : "week";

    useEffect(() => {
        setIsLoading(true);
        getCalendarStatisticsMonth(periodQuery)
            .then(response => {
                setData(transformDataGraph(response, period));
                setIsEmpty(response.dates.length === 0);
                setIsLoading(false);
            })
            .catch(error => {
                console.error('Error fetching bar chart:', error);
                setIsLoading(false);
            });
    }, [period, periodQuery]);

    if (isLoading) {
        return <div className="flex justify-center items-center h-full"><CircularProgress /></div>;
    }

    if (isEmpty) {
        return <div className="flex justify-center items-center h-full text-main-blue text-2xl font-thin">No Data</div>;
    }

    return (
        <div className="flex flex-col h-full w-full">
            <p className="text-xl sm:text-2xl font-thin text-dark-blue ml-5 mt-3 mb-0">Graph</p>
            <div className="flex-grow h-[30vh] mid:h-[40vh] w-full">
                {data && <IncidentBarChart data={data} />}
            </div>
        </div>
    );
}
