import React, { useState } from 'react'
import LoginUI from '../components/Login/LoginUI.jsx'
import RegisterUI from '../components/Login/RegisterUI.jsx'

function Login() {
  const [isLogin, setIsLogin] = useState(true);

  return (
    <section className='bg-gradient-to-b from-[#1b1b1b] to-black w-full flex py-[1rem]'>
      <div className='max-w-[1240px] w-[700px] black-bg flex flex-col mx-auto p-5 rounded-[2rem] shadow-lg'>
        {isLogin ?
        (<LoginUI setIsLoginCallback={() => setIsLogin(false)}/>)
        :
        (<RegisterUI setIsLoginCallback={() => setIsLogin(true)}/>)}
      </div>
    </section>
  )
}

export default Login