import React from 'react'
import Laptop from '../assets/laptop.jpg'

function Analytics() {
  return (
    <div className='w-full bg-white py-16 px-4'>
        <div className='max-w-[1240px] mx-auto grid md:grid-cols-2'>
            <img className='w-[500px] mx-auto my-4' src={Laptop} alt="laptop" />
            <div className='flex flex-col justify-center'>
                <p className='text-ddGreen font-bold'>TEST TITLE ABOUT SOMETHING</p>
                <h1 className='black-font font-bold md:text-4xl sm:text-3xl text-2xl py-2'>Extra info header</h1>
                <p className='black-font'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ex sint facere hic maxime deleniti ad totam voluptates officiis dignissimos doloremque?</p>
                <button className='bg-black w-[200px] rounded-md font-medium my-6 mx-auto md:mx-0 py-3 text-ddGreen'>Test button</button>
            </div>
        </div>
    </div>
  )
}

export default Analytics