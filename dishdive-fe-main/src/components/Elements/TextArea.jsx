import React from 'react'

function TextArea({label, type, placeholder = label, name, value, onChange}) {
  return (
    <>
      {label && <p className='font-bold text-sm mb-[0.5rem]'>{label}</p>}
      <div className='relative'>
        <textarea 
        className={`p-3 flex w-full h-[200px] rounded-md text-ddWhite placeholder-ddGrey bg-ddInputBg mb-[16px] outline-none focus:ring-2 focus:ring-ddGreen hover:ring-2 hover:ring-ddGrey `} 
        type={type === 'password' ? (showPassword ? 'text' : 'password') : type}
        placeholder={placeholder} 
        name={name}
        value={value} 
        onChange={onChange}
        ></textarea>
      </div>
    </>
  )
}

export default TextArea