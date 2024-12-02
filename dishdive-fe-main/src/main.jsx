import React from 'react'
import { createRoot } from 'react-dom/client';
import{
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom"
import './index.css'

import Root from "./pages/Root.jsx"
import Error from "./pages/Error.jsx"
import Home from './pages/Home.jsx'
import Recipes from './pages/Recipes.jsx'
import Recipe from './pages/recipe/Recipe.jsx'
import About from './pages/About.jsx'
import Login from './pages/Login.jsx'
import Test from './pages/Test.jsx';
import Create from './pages/Create.jsx';
import Profile from './pages/Profile.jsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root/>,
    errorElement: <Error/>,
    children:[
      {path: "/", element: <Home/>},
      {path: "/recipes/:searchFilter?",element: <Recipes/>},
      {path: "/recipe/:id",element: <Recipe/>},
      {path: "/about",element: <About/>},
      {path: "/login",element: <Login/>},
      {path: "/create",element: <Create/>},
      {path: "/chat/:name",element: <Test/>},
      {path: "/profile/:id",element: <Profile/>}
    ]
  },
]);

createRoot(document.getElementById('root')).render(
  <RouterProvider router={router}/>
)

