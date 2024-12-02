import React, { useEffect } from 'react'
import Navbar from '../components/Header/Navbar'
import Footer from '../components/Footer/Footer'
import { Outlet } from 'react-router-dom'
import useAuthStore from '../utility/auth/authStore';

function Root() {
  const { setToken } = useAuthStore();
  
  useEffect(() => {
    const token = localStorage.getItem('dishdiveToken');
    setToken(token);
  }, []);

  return (
    <>
      <Navbar/>
      <Outlet/>
      <Footer/>
    </>
  )
}

export default Root