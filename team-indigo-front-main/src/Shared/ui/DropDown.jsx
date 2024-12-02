import React from 'react'

export default function DropDown({
    label = '', 
    options = [], 
    onChange, 
    className = '' 
}) {
  return (
    <div className={`flex flex-col w-[327px] h-[47px] relative mr-[10px] mb-[10px] ${className}`}>
        {label && <label for="dropdown" >{label}</label>}
        <select id='dropdown' className='text-[15px] cursor-pointer rounded-[2px] ' onChange={onChange} defaultValue=''>
            <option value='' disabled hidden>Select an option</option>
            {options.map((option, index) => (
                <option 
                    key={index} 
                    value={option}>{option}
                </option>
            ))}
        </select>
    </div>
  )
}