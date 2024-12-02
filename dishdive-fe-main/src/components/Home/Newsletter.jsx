import React from 'react'
import Button from '../Elements/Button'
import Input from '../Elements/Input'

function Newsletter() {
  return (
    <div className='w-full py-16 px-4'>
        <div className='max-w-[1240px] mx-auto grid lg:grid-cols-3'>
            <div className='lg:col-span-2 md:mr-4'>
                <h1 className='md:text-4xl sm:text-3xl text-2xl font-bold py-2'>Stay up-to-date</h1>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptas, adipisci consequatur reprehenderit vero consectetur illum.</p>
            </div>
            <div className='my-4'>
                <div className='flex flex-col sm:flex:row items-center justify-between w-full'>
                    <Input type="email" placeholder='Enter email'/>
                    <Button text="Notify me" className='my-6 mr-auto'/>
                </div>
                <p>I promise I won't sell your data to a scam call center <span className='text-ddGreen'>Terms and conditions</span></p>
            </div>
        </div>
    </div>
  )
}

export default Newsletter