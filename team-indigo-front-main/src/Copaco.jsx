import {Route, Routes,Navigate} from "react-router-dom";
import LoginPage from "./pages/Login/LoginPage.jsx";
import PageLayout from "./Layout/PageLayout.jsx";
import Test from './Test.jsx'
import PostFormPage from "./pages/Form/PostFormPage.jsx";
import Dashboard from './pages/Dashboard/Dashboard.jsx';
import { AuthenticatedTemplate, UnauthenticatedTemplate, useMsal, MsalProvider } from "@azure/msal-react";
import { loginRequest } from "./Shared/Auth/Config.js";
import Statistic from "./pages/Statistics/Statistic";
import {Build} from "@mui/icons-material";
import BuildingPage from "./pages/Building/BuildingPage.jsx";

const WrappedView = () => {
    const {instance} = useMsal();
    const activeAccount = instance.getActiveAccount();

    const handleRedirect = () => {
        instance
            .loginRedirect({
                ...loginRequest,
                prompt: 'create',
            })
            .catch((error) => console.log(error));
    };

    const handleLogout = () => {
        instance.logout();
    }

    return (
        <>
            <AuthenticatedTemplate>
                {activeAccount ? (
                    <Routes>
                    <Route
                        path="/post/*"
                        element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<PostFormPage/>} />
                                </Routes>
                            </PageLayout>
                        }
                    />
                    <Route
                        path="/*"
                        element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<Navigate to={"/post"}/>} />
                                </Routes>
                            </PageLayout>
                        }
                    />
                    <Route path='/test' element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<Test />} />
                                </Routes>
                            </PageLayout>
                        }/>
                    <Route path='/dashboard' element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<Dashboard />} />
                                </Routes>
                            </PageLayout>
                        }/>

                        <Route path='/posted' element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<Dashboard />} />
                                </Routes>
                            </PageLayout>
                        }/>


                    <Route path='/statistic' element={
                        <PageLayout>
                            <Routes>
                                <Route index element={<Statistic />} />
                            </Routes>
                        </PageLayout>
                    }/>

                        <Route path='/building' element={
                            <PageLayout>
                                <Routes>
                                    <Route index element={<BuildingPage/>} />
                                </Routes>
                            </PageLayout>
                        }/>
                </Routes>
                ): null}
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <Routes>
                    <Route path="/*" element={<Navigate to={"/login"}/>} />
                    <Route path="/login" element={<LoginPage handleRedirect={handleRedirect}/>} />
                </Routes>
            </UnauthenticatedTemplate>
        </>
    );
};

const Copaco = ({instance}) => {
    return(
        <MsalProvider instance={instance}>
            <WrappedView/>
        </MsalProvider>
    )
}

export default Copaco;