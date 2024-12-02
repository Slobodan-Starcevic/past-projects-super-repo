import React from 'react'
import { useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faBars} from '@fortawesome/free-solid-svg-icons'

function Menu() {
    const [isHovered, setIsHovered] = useState(false);
  return (
    <div className='flex items-center'>
        <FontAwesomeIcon 
        icon={faBars}
        style={{
            color: isHovered ? "#003f75" : "#9f9f9f",
            marginLeft:"1rem", 
            marginTop: '1rem',
            transition: "font-size 0.3s ease-in-out, color 0.3s ease-in-out",
            transform: `scale(${isHovered?1.7:1.5})`,
            transformOrigin: "center center"
        }} 
        onMouseEnter={() => setIsHovered(true)}
        onMouseLeave={() => setIsHovered(false)}
        />
    </div>
  )
}

export default Menu