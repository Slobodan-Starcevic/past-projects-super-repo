import React, { useEffect } from 'react'
import Input from '../Elements/Input'
import Button from '../Elements/Button'
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';
import { createChef } from '../../API/chefAPI';
import { createPopup } from '../../utility/popupHandler';

function RegisterUI({setIsLoginCallback}) {
    const navigate = useNavigate();

    const [credentials, setCredentials] = useState({
        username: '',
        email: '',
        password: '',
        repeatPassword: ''
    });
    const [validationErrors, setValidationErrors] = useState({
        username: '',
        email: '',
        password: '',
        repeatPassword: ''
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;

        setCredentials((prevCredentials) => ({
            ...prevCredentials,
            [name]: value,
        }));

        validateInput(name, value)
    };

    const validateInput = (name, value) => {
        let error = '';
        
        switch(name){
            case 'username': 
                if (!value.trim()) {
                    error = 'Username is required';
                }else if(value.length < 3) {
                    error = 'Username must be at least 3 characters';
                }else if(value.length > 20){
                    error = 'Username may be at most 20 characters';
                }
                break;
            case 'email':
                if (!value.trim()) {
                    error = 'Email is required';
                } else if (!/^\S+@\S+\.\S+$/.test(value)) {
                    error = 'Invalid email format, format like name@domain.com required';
                }
                break;
            case 'password':
                if (!value.trim()) {
                    error = 'Password is required';
                } else if (value.length < 6) {
                    error = 'Password must be at least 6 characters';
                }else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$/.test(value)){
                    error = `Weak password. Atleast 1 uppercase, 1 lowercase letter and number required`;
                }
                break;
            case 'repeatPassword':
                if (value !== credentials.password) {
                    error = 'Passwords do not match';
                }
                break;
            default:
        }

        setValidationErrors((prevValidationErrors)=>({
            ...prevValidationErrors,
            [name]: error
        }));
    };

    const handleSignUp = async () => {
        const { username, email, password, repeatPassword } = credentials;
        const allValidationErrorsEmpty = Object.values(validationErrors).every(value => value === '');
        const allCredentialsEmpty = Object.values(credentials).some(value => value === '');

        if(!allCredentialsEmpty && allValidationErrorsEmpty){
            createChef({username, email, password})
          .then((response) => {
            if(response){
              createPopup("succes", "Account creation succesful")
              setIsLoginCallback()
              navigate("/login", {replace: true});
            }
          })
          .catch(error => createPopup("error", error.message));
        } else {
            validateInput("username", username);
            validateInput("email", email);
            validateInput("password", password);
            validateInput("repeatPassword", repeatPassword);
            createPopup("error", "Invalid credentials")
        }
    }

    return (
        <>
            <h1 className='text-4xl font-bold self-center my-[48px]'>Sign up to <span className='text-ddGreen'>DISH</span>DIVE.</h1>
            <div className='w-[100%] flex flex-col px-[10rem] justify-center'>
                <Input label={"Username"} type="text" name='username' value={credentials.username} onChange={handleInputChange} />
                {validationErrors.username && <span className='mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.username}</span>}
                <Input label={"Email"} type="text" name='email' value={credentials.email} onChange={handleInputChange} />
                {validationErrors.email && <span className='mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.email}</span>}
                <Input label={"Password"} type="password" name='password' value={credentials.password} onChange={handleInputChange} />
                {validationErrors.password && <span className='mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.password}</span>}
                <Input label={"Repeat Password"} type="password" name='repeatPassword' value={credentials.repeatPassword} onChange={handleInputChange} />
                {validationErrors.repeatPassword && <span className='mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.repeatPassword}</span>}
                <div className='mx-auto w-[100%]'>
                    <Button text="Sign Up" className='mt-[40px]' onClick={handleSignUp} />
                </div>
            </div>
            <hr className='my-[2.5rem] mx-[4.5rem] border-ddGrey2' />
            <p className='text-center w-full text-ddGrey'>
                Already have an account?
                <span onClick={() => setIsLoginCallback()} className='text-white hover:text-ddGreen cursor-pointer'> Sign In</span>
            </p>
        </>
    )
}

export default RegisterUI