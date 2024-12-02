import React from 'react'
import DummyPic from '../../assets/food.jpg'
import { toPascalCase } from "../../utility/CapitalisationService"
import { getTimeAgo } from '../../utility/TimeAgoCalculator'
import { Rating } from '@mui/material';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import useAuthStore from '../../utility/auth/authStore';
import { useNavigate } from 'react-router-dom';


function RecipeBody1({recipe, handleEditSwitch, isEditing, handlePostDelete}) {
  const {user} = useAuthStore();
  const navigate = useNavigate();

  const handleProfileNav = () => {
    navigate(`/profile/${recipe.poster.id}`);
  }
  return (
    <div className='flex justify-center max-w-[1240px] mx-auto bg-black p-[4rem] rounded-t-[2rem]'>
        <div className='rounded-tl-[1rem] overflow-hidden'>
          <img src={DummyPic} alt={`picture of ${recipe.title}`} />
        </div>
        <div className='flex flex-[50%] flex-col px-10 space-y-4'>
          <div className='flex items-center justify-between'>
            <p className='font-semibold text-3xl'>{recipe.title}</p>
            {user && (user.userId === recipe.poster.id || user.role == "ADMIN") && (
              <div className='flex space-x-5'>
                <i onClick={handleEditSwitch} className="fa-solid fa-pen-to-square fa-xl flex text-ddGreen cursor-pointer"></i>
                <i onClick={() => handlePostDelete(recipe.id)} className="cursor-pointer fa-solid fa-trash fa-xl flex text-ddGreen"></i>
              </div>
            )}
            </div>
            {!isEditing && <Rating
            value={recipe.rating}
            precision={0.1}
            emptyIcon={<StarBorderIcon style={{ color: '#5c5c5c' }} />}
            readOnly
          />}
          <div className='flex flex-col'>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-user text-ddGreen"></i>
                <p>Made by <span onClick={handleProfileNav} className='text-ddGreen hover:underline cursor-pointer'>{toPascalCase(recipe.poster.username)}</span></p>
            </div>
            <div className='border border-ddGrey2 m-1'></div>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-upload text-ddGreen"></i>
                <p>Uploaded {getTimeAgo(recipe.creationTime)} ago</p>
            </div>
            <div className='border border-ddGrey2 m-1'></div>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-clock text-ddGreen"></i>
                <p>Prep time {recipe.prepTime} mins</p>
            </div>
            <div className='border border-ddGrey2 m-1'></div>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-clock text-ddGreen"></i>
                <p>Cooking time {recipe.cookTime} mins</p>
            </div>
            <div className='border border-ddGrey2 m-1'></div>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-chart-pie text-ddGreen"></i>
                <p>{recipe.servings} Servings</p>
            </div>
            <div className='border border-ddGrey2 m-1'></div>
            <div className='flex flex-row items-center space-x-2'>
                <i className="fa-solid fa-tag text-ddGreen"></i>
                <p>{toPascalCase(recipe.recipeTag)}</p>
            </div>
        </div>
    </div>
    </div>
  )
}

export default RecipeBody1