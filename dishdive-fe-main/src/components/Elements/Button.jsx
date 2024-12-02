import React from 'react'

function Button({text, className , onClick}) {
  return (
    <button className={`bg-ddGreen w-[100%] rounded-[2rem] font-bold px-6 py-3 text-black ${className}`} onClick={onClick}>{text}</button>
  )
}

export default Button