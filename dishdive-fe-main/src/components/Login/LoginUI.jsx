import React from 'react'
import { createPopup } from '../../utility/popupHandler';
import Input from '../Elements/Input.jsx'
import Button from '../Elements/Button.jsx'
import GooglePic from '../../assets/google.png'
import { loginChef} from '../../API/chefAPI.jsx'
import { useNavigate } from 'react-router-dom'
import useAuthStore from '../../utility/auth/authStore.js'
import { useState } from 'react';

function LoginUI({setIsLoginCallback}) {
    const { setToken } = useAuthStore();
    const navigate = useNavigate();

    const [username, setUsernameOrEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        loginChef({username, password})
          .then((response) => {
            if(response){
              setToken(response);
              createPopup("succes", "Login succesful")
              navigate("/", {replace: true});
            }
          })
          .catch(error => createPopup("error", error.message));
    }
      
    return (
        <>
            <h1 className='text-4xl font-bold self-center mt-[48px] mb-[100px]'>Log in to <span className='text-ddGreen'>DISH</span>DIVE.</h1>
            <div className='w-[100%] flex flex-col px-[10rem] justify-center'>
                <Input label={"Username or Email"} type="text" value={username} onChange={(e) => setUsernameOrEmail(e.target.value)} />
                <Input label={"Password"} type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                <div className='mx-auto w-[100%]'>
                    <Button text="Sign In" className='mb-[20px] mt-[40px]' onClick={handleLogin} />
                </div>
            </div>
            <hr className='my-[2.5rem] mx-[4.5rem] border-ddGrey2' />
            <div className='flex'>
                <p className='text-center w-full text-ddGrey'>Don't have an account?
                    <span onClick={() => setIsLoginCallback()} className='text-white hover:text-ddGreen cursor-pointer'> Sign Up</span>
                </p>
            </div>
        </>
    )
}

export default LoginUI