import logo from "../../assets/img/logo.jpeg";
import React from "react";
import microsoft from "../../assets/img/microsoft.png";


function LoginPage({handleRedirect}) {

    const handleLogin = async() => {
        await handleRedirect();
    }

    return (
        <div className="container flex justify-center mt-5">
            <div className="p-[5%] flex flex-grow flex-column items-center max-w-[500px]">
                <img src={logo} className="w-50 mb-5 mt-2" />
                <div className="bg-main-blue w-full flex flex-row text-center p-2 text-white font-bold rounded-md my-4" >
                    <img src={microsoft} alt="" className="w-10"/>
                    <button className="w-full items-center flex justify-center" onClick={() => handleLogin()}>LOGIN WITH MICROSOFT</button>
                </div>
            </div>
        </div>
    )
}

export default LoginPage