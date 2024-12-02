import IncidentTypePieChart from "./PieChartTypes/IncidentTypePieChart.jsx";
import {CircularProgress} from "@mui/material";
import {useEffect, useState} from "react";
import {transformDataPie} from "../../Shared/utility/transformData.jsx";

export default function PieChartSection({data}){


    const [pieData, setPieData] = useState(transformDataPie(data));

    const [pieDataTable, setPieDataTable] = useState(data);

    const [totalIncidents, setTotalIncidents] = useState(data.types.reduce((acc, curr) => acc + curr.incidents, 0));




    return(
        <div>
            <div className="flex flex-col ml-0">
                <div className="flex flex-row justify-between w-full mid:w-[76vw] h-[60vh] mid:h-[30vh]">
                    { data.types.length === 0 ?
                        <div className="flex w-[80vw] text-main-blue text-2xl font-thin h-full justify-center items-center">
                            No Data
                        </div>
                        :
                        <div className=" flex flex-col mid:flex-row w-100">
                            <div className=" ml-5 w-[60%] mid:w-[40%] h-full" >
                                <IncidentTypePieChart data={pieData} />
                            </div>
                            <div className="m-4 w-[92%] mid:w-[50%] h-full">
                                <table className="w-full my-2">
                                    <tbody className="font-light">
                                    {[...pieDataTable.types]
                                        .sort((a, b) => b.incidents - a.incidents)
                                        .map((item, index) => {
                                            const percentage = ((item.incidents / totalIncidents) * 100).toFixed(0);
                                            return(
                                                <tr key={index} className="h-[40px] border-b border-main-blue">
                                                    <td className="w-[60%]">{item.name}</td>
                                                    <td className="w-[25%]">{item.incidents}</td>
                                                    <td className="w-[15%]">{percentage}%</td>
                                                </tr>
                                            );
                                        })}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    }
                </div>
            </div>
        </div>
    )
}