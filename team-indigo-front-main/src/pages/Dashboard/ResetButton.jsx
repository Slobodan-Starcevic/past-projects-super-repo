import React from 'react'

function ResetButton({resetFilters, className, text}) {

    const handleRemoveFilter = () => {
        resetFilters();
    }

  return (
    <>
    <div className={`relative cursor-pointer  text-black bg-gray-200 hover:bg-slate-300 ${className}`}>
        <button onClick={handleRemoveFilter} className='w-full h-full py-2 px-4 font-semibold'>{text}</button>
    </div>
    </>
    
  )
}

export default ResetButton