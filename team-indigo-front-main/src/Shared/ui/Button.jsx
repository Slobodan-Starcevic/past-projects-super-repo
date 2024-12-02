import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faChevronRight} from '@fortawesome/free-solid-svg-icons'

function Button({text, chevron=false, className = "", onClick}) {
  return (
    <button
        onClick={onClick}
        className={` ${className} text-[#fff] py-[10px] px-[40px] mr-[10px] mb-[10px] capitalize rounded-[2px] bg-dark-blue border-b-[2px] border-solid border-[#00335f] font-sans font-medium duration-300`}>
        {text}
        {chevron && <FontAwesomeIcon icon={faChevronRight} size='sm' style={{color: "#ffffff", margin: "0 0 0 10px"}} />}
    </button>
  )
}

export default Button