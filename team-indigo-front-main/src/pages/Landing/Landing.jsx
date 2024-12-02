import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faMagnifyingGlass, faPenNib} from '@fortawesome/free-solid-svg-icons'

function Landing() {
  return (
    <>
      <section className='h-[100vh] px-[20%] flex flex-col justify-center items-center'>
        <h1 className='mb-5'>Quick navigation</h1>
        <a href='/post' className='border-2 border-main-blue rounded text-decoration-none text-black p-[15px] flex-col w-[180px] h-[] flex items-center text-center'>
          <FontAwesomeIcon icon={faPenNib} style={{marginBottom: "8px", width: "28px", height: "28px"}}/>
          <div className='w-full text-lg font-semibold'>Make a report</div>
        </a>
        <hr />
        <a href='/dashboard' className='border-2 border-main-blue rounded text-decoration-none text-black p-[15px] flex-col w-[180px] flex items-center text-center'>
          <FontAwesomeIcon icon={faMagnifyingGlass} style={{marginBottom: "8px", width: "28px", height: "28px"}}/>
          <div className='w-full text-lg font-semibold'>View reports</div>
        </a>
      </section>
    </>
  )
}

export default Landing