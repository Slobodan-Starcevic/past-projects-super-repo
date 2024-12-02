
import {useEffect, useState} from "react";

import BarChartSection from "./BarChart/BarChartSection";
import PieChartTypesSection from "./PieChartTypes/PieChartTypesSection";
import PeriodSelector from "./PeriodSection.jsx";
import PieChartSeveritySection from "./PieChartSeverity/PieChartSeveritySection";
import { useNavigate } from "react-router";
import { useMsal } from "@azure/msal-react";

export default function Statistic() {
    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();
    const isAuthorized = (activeAccount.idTokenClaims.roles[0] !== "regular_staff");
    const navigate = useNavigate();

    useEffect(() => {
        if(!isAuthorized){
            navigate(to="/")
        }
    }, [])
    const [selectedPeriod, setSelectedPeriod] = useState('All Time');

    return (
        <div className="container-lg pt-2">
            <div className="flex flex-col justify-center items-center">
                <PeriodSelector onSelectPeriod={setSelectedPeriod} />
                <div className="border rounded-md shadow-md my-5 p-2 w-100">
                    <BarChartSection period={selectedPeriod} />
                </div>
                <div className="flex mid:flex-row flex-col w-100">
                    <div className="flex flex-col justify-center items-stretch mid:mr-5">
                        <div className="border rounded-md shadow-md my-5 p-2">
                            <PieChartTypesSection period={selectedPeriod}/>
                        </div>
                        <div className="border rounded-md shadow-md my-5 p-2">
                            <PieChartSeveritySection period={selectedPeriod}/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
