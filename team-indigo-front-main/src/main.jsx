import React from 'react';
import {createRoot} from 'react-dom/client';
import {BrowserRouter} from "react-router-dom";
import './index.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import Copaco from "./Copaco";
import { PublicClientApplication, EventType } from "@azure/msal-browser";
import { config } from './Shared/Auth/Config'

const msalInstance = await PublicClientApplication.createPublicClientApplication(config);

if(!msalInstance.getActiveAccount() && msalInstance.getAllAccounts().length > 0){
    msalInstance.setActiveAccount(msalInstance.getActiveAccount()[0]);
}

msalInstance.addEventCallback((event) => {
    if(event.eventType === EventType.LOGIN_SUCCESS && event.payload.account) {
        const account = event.payload.account;
        msalInstance.setActiveAccount(account);
    }
});


createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <BrowserRouter>
                <Copaco instance={msalInstance}/>
        </BrowserRouter>
    </React.StrictMode>
);
