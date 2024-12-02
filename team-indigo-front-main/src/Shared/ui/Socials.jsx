import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faInstagram} from '@fortawesome/free-brands-svg-icons'
import {faFacebook} from '@fortawesome/free-brands-svg-icons'
import {faTwitter} from '@fortawesome/free-brands-svg-icons'
import {faYoutube} from '@fortawesome/free-brands-svg-icons'

function Socials() {
  return (
    <div className='flex'>
        <button className='w-[32px] h-[32px] text-base rounded-full bg-dark-blue flex items-center justify-center mr-[10px] mb-[10px]'>
            <FontAwesomeIcon icon={faInstagram} size="lg" style={{color: "#ffffff",}}/>
        </button>
        <button className='w-[32px] h-[32px] text-base rounded-full bg-dark-blue flex items-center justify-center mr-[10px] mb-[10px]'>
            <FontAwesomeIcon icon={faFacebook} size="lg" style={{color: "#ffffff",}}/>
        </button>
        <button className='w-[32px] h-[32px] text-base rounded-full bg-dark-blue flex items-center justify-center mr-[10px] mb-[10px]'>
            <FontAwesomeIcon icon={faTwitter} size="lg" style={{color: "#ffffff",}}/>
        </button>
        <button className='w-[32px] h-[32px] text-base rounded-full bg-dark-blue flex items-center justify-center mr-[10px] mb-[10px]'>
            <FontAwesomeIcon icon={faYoutube} size="lg" style={{color: "#ffffff",}}/>
        </button>
    </div>
  )
}

export default Socials