import {useEffect, useState} from "react";
import PieChartSection from "../PieChartSection.jsx";
import {GetSeverityStatisticMonth} from "../../../Shared/API/statistics/GetSeverityStatisticMonth.jsx";
import {CircularProgress} from "@mui/material";

export default function PieChartSeveritySection({period}){

    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(false);

    const periodQuery = period === "All Time" ? "allTime" : period === "1 Year" ? "year" : period === "1 Month" ? "month" : "week";

    useEffect(() => {
        setIsLoading(true);
        GetSeverityStatisticMonth(periodQuery)
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
                        <p className="text-2xl font-thin text-dark-blue ml-5 mt-3">Severity</p>
                        <div className="flex-grow">
                            <PieChartSection data={data} />
                        </div>
                    </div>

                )
            )}
        </div>
    );
}