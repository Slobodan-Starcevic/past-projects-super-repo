import React from 'react'
import {
    FaDribbbleSquare,
    FaFacebookSquare,
    FaGithubSquare,
    FaInstagram,
    FaTwitterSquare
} from 'react-icons/fa'

function Footer() {
  return (
    <div className='max-w-[1240px] mx-auto py-16 px-4 grid lg:grid-cols-3 gap-8 text-gray-300'>
        <div>
            <h1 className='w-full text-3xl font-bold text-ddGreen'>DISH<span className='white-font'>DIVE.</span> </h1>
            <p className='py-4'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Adipisci mollitia, esse temporibus tempore quis exercitationem. Quo laboriosam, eligendi est sunt nesciunt cumque voluptates voluptatibus ad quaerat culpa. Quam, at delectus!</p>
            <div className='flex justify-between md:w-[75%]'>
                <FaFacebookSquare size={30}/>
                <FaInstagram size={30}/>
                <FaTwitterSquare size={30}/>
            </div>
        </div>
        <div className='lg:col-span-2 flex justify-between lg:mt-6'>
            <div>
                <h6 className='font-medium text-gray-400'>Whatdodo</h6>
                <ul>
                    <li className='py-2 text-sm'>Recipes</li>
                    <li className='py-2 text-sm'>Chefs</li>
                    <li className='py-2 text-sm'>Ideas</li>
                    <li className='py-2 text-sm'>Events</li>
                </ul>
            </div>
            <div>
                <h6 className='font-medium text-gray-400'>Company</h6>
                <ul>
                    <li className='py-2 text-sm'>About</li>
                    <li className='py-2 text-sm'>Employees</li>
                    <li className='py-2 text-sm'>Blog</li>
                    <li className='py-2 text-sm'>Careers</li>
                </ul>
            </div>
            <div>
                <h6 className='font-medium text-gray-400'>Support</h6>
                <ul>
                    <li className='py-2 text-sm'>Account</li>
                    <li className='py-2 text-sm'>Guides</li>
                    <li className='py-2 text-sm'>API status</li>
                    <li className='py-2 text-sm'>Contact</li>
                </ul>
            </div>
            <div>
                <h6 className='font-medium text-gray-400'>Legal</h6>
                <ul>
                    <li className='py-2 text-sm'>Claim</li>
                    <li className='py-2 text-sm'>Policy</li>
                    <li className='py-2 text-sm'>Terms</li>
                </ul>
            </div>
        </div>
    </div>
  )
}

export default Footer