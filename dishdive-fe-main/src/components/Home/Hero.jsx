import React, { useEffect } from 'react'
import Input from '../Elements/Input'
import Button from '../Elements/Button'
import { useState } from 'react';
import { getAllRecipes } from '../../API/recipeAPI';
import {getTimeAgo} from '../../utility/TimeAgoCalculator'
import { useNavigate } from 'react-router-dom';
import { createPopup } from '../../utility/popupHandler';

function Hero() {
  const [search, setSearch] = useState("");
  const [searchResults, setSearchResults] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    if(search.length > 1){
      getAllRecipes({
        params: {
          page: 1,
          pageSize: 6,
          search: search
        }
      })
      .then((response) => {
      if(response){
        console.log(response.data.recipes)
        setSearchResults(response.data.recipes)
      }})
      .catch(error => createPopup("error", error.message));
  }}, [search])

  const handleSearchChoice = (id) => {
    navigate(`/recipe/${id}`);
  }

  const handleRawSearch = () => {
    navigate(`/recipes/${search}`);
  }

  return (
    <div className='text-white'>
        <div className='max-w-[800px] mt-[-96px] w-full h-screen mx-auto text-center flex flex-col justify-center'>
            <p className='text-2xl text-ddGreen font-bold p-2 '>OH HE COOKIN'</p>
            <div className='relative flex-col w-full'>
              <div className='w-full flex'>
                <Input type="text" placeholder="Chicken Teriyaki" className={"w-full"} value={search} onChange={e => setSearch(e.target.value)}/>
                <Button text="Dive in" className={"ml-4 w-[200px] h-[3rem] rounded-md"} onClick={handleRawSearch}/>
              </div>
              <div className='absolute w-[618px] mt-[-10px] bg-ddInputBg rounded-md overflow-hidden'>
              {
                searchResults.slice(0, 5).map((recipe, index) => (
                  <div key={index} onClick={() => handleSearchChoice(recipe.id)} className='flex hover:bg-ddGrey2 cursor-pointer p-3 px-10 justify-between'>
                    <div className='relative flex space-x-10'>
                      <p className='absolute max-w-[8rem] overflow-hidden whitespace-nowrap overflow-ellipsis'>{recipe.title}</p>
                      <p className='pl-[7rem]'>By {recipe.poster.username}</p>
                    </div>
                    <p>{getTimeAgo(recipe.creationTime)} ago</p>
                  </div>
                ))
              }
              {
                searchResults.length > 5 && (
                  <div onClick={handleRawSearch} className='flex hover:bg-ddGrey2 cursor-pointer p-3 px-10 justify-between'>
                    <p>More...</p>
                  </div>
                )
              }
              </div>
            </div>
            <p className='md:text-2xl text-xl font-bold text-gray-500'>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
        </div>
    </div>
  )
}

export default Hero