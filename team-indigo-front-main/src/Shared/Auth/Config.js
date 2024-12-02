import { LogLevel } from "@azure/msal-browser";

export const config = {
    auth: {
        clientId: '11dbe1d8-ac48-4eec-8d86-5e2b7f8cacf2',
        redirectUri: '/',
        postLogoutRedirectUri: "/login",
        authority: 'https://login.microsoftonline.com/33d45bbe-fe1e-4bd9-bca6-c3821f4ee536',
        navigateToLoginRequestUrl: false,
    },
    cache: {
        cacheLocation: 'sessionStorage',
        storeAuthStateInCookie: false,
    },
    system: {
        loggerOptions: {
            loggerCallback: (level, message, containsPii) => {
                if(containsPii){
                    return;
                }
                switch(level){
                    case LogLevel.Error:
                        console.error(message);
                        return;
                    case LogLevel.Info:
                        console.log(message);
                        return;
                    case LogLevel.Verbose:
                        console.log(message);
                        return;
                    case LogLevel.Warning:
                        console.warn(message);
                        return;
                    default:
                        return;
                }
            },
        },
    },
};

export const loginRequest = {
    scopes: ['openid', 'profile', 'email', 'user.read'],
}