import React, { useRef, useEffect } from 'react'
import {AiOutlineClose, AiOutlineMenu} from 'react-icons/ai'
import { useState } from 'react'
import { NavLink, Navigate, useNavigate } from 'react-router-dom'
import useAuthStore from '../../utility/auth/authStore'
import { createPopup } from '../../utility/popupHandler'

function Navbar() {
  const [nav, setNav] = useState(false)
  const navigate = useNavigate();
  const { user, setToken} = useAuthStore();
  const [showDropdown, setShowDropdown] = useState(false);
  const dropdownRef = useRef(null);

  useEffect(() => {
    document.addEventListener('click', handleClickOutside);
    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, []);

  const toggleDropdown = () => {
    setShowDropdown(!showDropdown);
  };
  const handleClickOutside = (event) => {
    if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
      setShowDropdown(false);
    }
  };
  const handleNav = () => {
    setNav(!nav)
  }

  const handleLogout = async () => {
    setToken(null);
    createPopup("succes", "Succesfully logged out")
    navigate("/login", {replace: true});
  }

  const handleNavigate = (path) => {
    const {userId} = user;
    navigate(`${path}/${userId}`);
  }

  return (
    <div className='text-white flex justify-between items-center h-24 max-w-[1240px] mx-auto px-4'>
        <NavLink to="/">
          <h1 className='w-full text-3xl font-bold text-ddGreen'>DISH<span className='white-font'>DIVE.</span> </h1>
        </NavLink>
        <ul className='flex items-center font-bold'>
          <li className='p-2 h-[3rem] pt-[7px] border border-ddGreen text-ddGreen rounded-[1rem] flex justify-center text-center items-center hover:bg-ddGreen hover:text-black'>
            <NavLink to="/create" activeclassname="active" >Create recipe</NavLink></li>
          <li className='p-4'><NavLink to="/" activeclassname="active">Home</NavLink></li>
          <li className='p-4'><NavLink to="/recipes" activeclassname="active">Recipes</NavLink></li>

          {user ? (
          <li className="relative" ref={dropdownRef}>
            <button
              onClick={toggleDropdown}
              className={`p-2 h-[3rem] pt-[7px] ${!showDropdown ? "text-ddGreen bg-black" : "bg-ddGreen hover:text-black"} rounded-sm flex justify-center items-center `}
                  >{user.username}{showDropdown ? <i class="fa-solid fa-chevron-up m-2"></i> : <i className="fa-solid fa-chevron-down m-2"></i>}</button>
                  {showDropdown && (
                    <div className="absolute top-11 right-0 bg-ddGreen rounded-b-sm overflow-hidden">
                      <button className='w-full hover:border-ddGreen hover:text-black p-3' onClick={() => handleNavigate("/profile")} >Profile</button>
                      <button className='w-full hover:border-ddGreen hover:text-black p-3' onClick={handleLogout}>Logout</button>
                    </div>
                  )}
                </li>
              ) : (
                <li className='p-4 border-b border-gray-600'>
                  <NavLink to="/login">
                    Login
                  </NavLink>
                </li>
              )}

        </ul>

        <div onClick={handleNav} className='block md:hidden'>
          {nav ? <AiOutlineClose size={20}/> :<AiOutlineMenu size={20}/>}
        </div>

        <div className={nav ? 'fixed right-0 top-0 w-[60%] h-full border-r border-r-gray-900 bg-[#000300] ease-in-out duration-500' : 'fixed right-[-100%]'}>
          <div onClick={handleNav} className='block p-4 cursor-pointer'><AiOutlineClose size={20}/></div>
          <ul className='uppercase p-4'>
            <li className='p-4 border-b border-gray-600'><NavLink onClick={() => handleNav()} to="/" activeclassname="active">Home</NavLink></li>
            <li className='p-4 border-b border-gray-600'><NavLink onClick={() => handleNav()} to="/recipes" activeclassname="active">Recipes</NavLink></li>
            <li className='p-4 border-b border-gray-600'><NavLink onClick={() => handleNav()} to="/about" activeclassname="active">About</NavLink></li>
            {!user ? <li className='p-4 border-b border-gray-600'><NavLink onClick={() => handleNav()} to="/login" activeclassname="active">Login</NavLink></li>
            : <li className='p-4 border-b border-gray-600'><NavLink onClick={() => handleLogout}>Logout</NavLink></li>}
          </ul>
        </div>
    </div>
  )
}

export default Navbar