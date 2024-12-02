import React from 'react'
import DummyPic from '../../assets/food.jpg'
import { getTimeAgo } from '../../utility/TimeAgoCalculator';
import { useNavigate } from 'react-router';
import ReactLoading from "react-loading";
import { Rating } from '@mui/material';
import StarBorderIcon from '@mui/icons-material/StarBorder';

function Cards({recipes}) {
  const navigate = useNavigate();

  const handleNavigation = (recipeId) => {
    navigate(`/recipe/${recipeId}`)
  }

  const handleProfileNav = (id) => {
    navigate(`/profile/${id}`);
  }

  return (
    <section className='w-full black-font bg-[#0000003d]'>
      <div className='w-full flex flex-wrap pl-[5px] '>
        {recipes ? recipes.map((item) => (
            <div key={item.id} onClick={() => handleNavigation(item.id)} className='w-[300px] shadow-xl flex flex-col my-4 mr-[8px] rounded-[1rem] hover:scale-105 duration-300 cursor-pointer text-ddWhite'>
              <div className='max-h-[200px] object-cover overflow-hidden'>
                <img src={DummyPic} alt={item.title} className='w-full object-cover rounded-[1rem]'/>
              </div>
              <div className='bg-black rounded-[1rem] mt-[-10px] p-4'>
                <h2 className='text-2xl font-bold mb-2 max-w-[18rem] overflow-hidden whitespace-nowrap overflow-ellipsis'>{item.title}</h2>
                <Rating
                value={item.rating}
                precision={0.1}
                emptyIcon={<StarBorderIcon style={{ color: '#5c5c5c' }} />}
                readOnly
                />
                <div className='flex mb-1'>
                  <p className='text-s'>by <span onClick={(e) => {handleProfileNav(item.poster.id); e.stopPropagation();}} className='font-bold text-ddGreen hover:underline'>{item.poster.username}</span></p>
                  <div className='border border-ddGrey2 mx-2'></div>
                  <p className='font-bold text-ddGreen'>{getTimeAgo(item.creationTime)} <span className='text-white font-medium'>ago</span></p>
                </div>
              </div>
            </div>
          )): 
          (<ReactLoading type='bubbles' />)}
      </div>
    </section>
  );
}

export default Cards