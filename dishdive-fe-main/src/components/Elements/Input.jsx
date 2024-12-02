import React from 'react'
import { useState } from 'react'

function Input({label = '', type, placeholder = label, name, value, onChange, className}) {
  const [showPassword, setShowPassword] = useState(false);

  const handlePasswordVisibility = () => {
    setShowPassword(!showPassword);
  }

  return (
    <>
    <div className={`flex-col ${className}`}>
    {label && <p className='font-bold text-sm mb-[0.5rem]'>{label}</p>}
      <div className='relative'>
        <input 
        className={`p-3 flex w-full rounded-md text-ddWhite placeholder-ddGrey bg-ddInputBg mb-[16px] outline-none focus:ring-2 focus:ring-ddGreen hover:ring-2 hover:ring-ddGrey `} 
        type={type === 'password' ? (showPassword ? 'text' : 'password') : type}
        placeholder={placeholder} 
        name={name}
        value={value} 
        onChange={onChange}
        ></input>
        {type == "password" && 
          <i className={`fa-regular ${showPassword ? 'fa-eye' : 'fa-eye-slash'} absolute top-0 right-0 mr-4 mt-[23px] fa-lg hover:color-white text-[#6a6a6a] hover:text-white`} onClick={handlePasswordVisibility}></i>
        }
      </div>
    </div>

    </>
  )
}

export default Input