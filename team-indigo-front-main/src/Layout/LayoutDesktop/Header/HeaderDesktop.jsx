import "./Header.css"
import logo from "../../../assets/img/logo.jpeg"
import SideBarItem from "./SideBarItem";
import logout from "../../../assets/img/logoutIcon.png"
import { useMsal } from "@azure/msal-react";
import { Client } from "@stomp/stompjs";
import React, { useEffect, useState } from "react";
import bellicon from "../../../assets/img/bellicon.jpg"
import belliconwithdot from "../../../assets/img/belliconwithdot.png"
import {Link} from "react-router-dom";

function HeaderDesktop() {
    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();
    const isAuthorized = (activeAccount.idTokenClaims.roles[0] !== "regular_staff");
    const [stompData, setStompData] = useState(0);

    useEffect(() => {
        setupStompClient();
    }, [stompData]);



    const setupStompClient = () => {
        // stomp client over websockets
        const stompClient = new Client({
          brokerURL: `ws://localhost:8080/ws`,
          reconnectDelay: 5000,
          heartbeatIncoming: 4000,
          heartbeatOutgoing: 4000,

        });
    
        stompClient.onConnect = () => {
          // subscribe to the backend public topic
          stompClient.subscribe(`/form`, (data) => {
            setStompData(stompData + 1);
            const body = JSON.parse(data.body);
            console.log("getting incoming form: ", body);

          });
        };
    
        // initiate client
        stompClient.activate();
    
        // maintain the client for sending and receiving
        return stompClient;
      };
    

    const handleLogout = () => {
        instance.logout();
    }
    return (
        //<Menu/>
        <div className="bg-main-white flex flex-column justify-between shadow-md w-[12%] h-100 bg position-fixed bg-white">
            <div>
                <img src={logo} alt="" className="px-4 "/>
                <SideBarItem name="Create Report" link="/post" />
                <SideBarItem name="View Reports" link="/dashboard?page=1" />
                {isAuthorized && <SideBarItem name="Statistic" link="/statistic" />}
                {isAuthorized && <SideBarItem name="Buildings" link="/building" />}
            </div>
            <div className="border-t pt-4 border-dark mx-4 my-2">
                <p className="pl-2 text-main-blue font-light" >
                    {activeAccount.name}
                </p>
                <div>
                    {stompData === 0 ? (
                        <img src={bellicon} alt="" className="w-8 h-8"/>
                    ) : (
                        <Link to="/dashboard?page=1"><img src={belliconwithdot} alt="" className="w-8 h-8"/></Link>
                    )}
                </div>
                <button onClick={() => handleLogout()} className="bg-main-blue flex flex-row items-center justify-center hover:bg-red-500 duration-300 text-center p-2 text-white font-light rounded-md mb-4">
                    Log Out
                    <img src={logout} className="h-5 ml-1" alt=""/>
                </button>
            </div>
    </div>
    );
}

export default HeaderDesktop
