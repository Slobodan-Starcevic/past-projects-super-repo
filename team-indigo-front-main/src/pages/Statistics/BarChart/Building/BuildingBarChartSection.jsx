import IncidentBarChart from "./IncidentBarChart.jsx";
import {useEffect, useState} from "react";
import {getCalendarStatisticsMonth} from "../../../Shared/API/statistics/getCalendarStatisticsMonth.jsx";
import {transformDataGraph} from "../../../Shared/utility/transformData.jsx";
import {CircularProgress} from "@mui/material";
import BuildingBarChart from "./BuildingBarChart";

export default function BuildingBarChartSection(){

    const [graphData, setGraphData] = useState(null);

    useEffect(() => {
        getCalendarStatisticsMonth()
            .then(response => {
                setGraphData(transformDataGraph(response));
            })
            .catch(error => {
                console.error('Error fetching graph:', error);
            });
    }, []);

    return(
        <div>
            { graphData ?
                <div className="w-[80vw] h-[30vh]">
                    <BuildingBarChart data={graphData}/>
                </div>
                :
                <CircularProgress/>
            }
        </div>
    )
}