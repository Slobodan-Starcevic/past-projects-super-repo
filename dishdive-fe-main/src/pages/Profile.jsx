import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getChefById, getChefRecipes } from '../API/chefAPI';
import { createPopup } from '../utility/popupHandler';
import DummyPic from '../assets/food.jpg'
import { Rating } from '@mui/material';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import { getTimeAgo } from '../utility/TimeAgoCalculator';
import PFP from '../assets/pfp.png'
import useAuthStore from '../utility/auth/authStore';


function Profile() {
  const [chef, setChef] = useState();
  const [chefRecipes, setChefRecipes] = useState([]);
  const { id } = useParams();
  const navigate = useNavigate();
  const {user} = useAuthStore();

  useEffect(() => {
    getChefById(id)
      .then((response) => {
        if (response && response.data) {
          console.log(response.data.chef);
          setChef(response.data.chef);
        }
      })
      .catch((error) => createPopup('error', error.message));

      getChefRecipes(id)
      .then((response) => {
        if (response) {
            console.log(response.data.recipeList)
          setChefRecipes(response.data.recipeList);
        }
      })
      .catch((error) => createPopup('error', error.message));
  }, [id]);

  

  const handleNavigation = (recipeId) => {
    navigate(`/recipe/${recipeId}`)
  }

  const handleChatNavigation = (id) => {
    navigate(`/chat/${id}`)
  };
  

  return (
    <section className='bg-gradient-to-b from-[#1b1b1b] to-black'>
        

        {chef && (
            <div className='w-full bg-black border-b border-ddGreen flex-col'>
                <img className='w-[200px] mb-7 mx-auto' src={PFP} alt="" />
                <div className='flex-col items-center justify-center text-center'>
                <h2 className='font-bold text-2xl'>Username: <span className='text-ddGreen'>{chef.username}</span></h2>
                <h2 className='font-bold text-2xl'>Posts: <span className='text-ddGreen'>{chefRecipes.length || 'None'}</span></h2>
                {chefRecipes.length > 0 && (
                    <div className='flex justify-center cursor-pointer mb-3' onClick={() => handleNavigation(chefRecipes.reduce((maxRatingRecipe, currentRecipe) => (
                        currentRecipe.rating > maxRatingRecipe.rating ? currentRecipe : maxRatingRecipe
                      )).id)}>
                        <h2 className='font-bold text-2xl'>
                            Best recipe:  
                            <span className='text-ddGreen ml-3'>
                            {chefRecipes.reduce((maxRatingRecipe, currentRecipe) => (
                                currentRecipe.rating > maxRatingRecipe.rating ? currentRecipe : maxRatingRecipe
                            )).title}
                            </span>
                        </h2>
                        <Rating
                            value={chefRecipes.reduce((maxRatingRecipe, currentRecipe) => (
                            currentRecipe.rating > maxRatingRecipe.rating ? currentRecipe : maxRatingRecipe
                            )).rating}
                            precision={0.1}
                            size='large'
                            emptyIcon={<StarBorderIcon style={{ color: '#5c5c5c' }} fontSize='3rem' />}
                            readOnly
                        />
                    </div>
                )}
                {chef.id != user.userId && <div className='flex justify-center items-center h-[3rem]'>
                    <i onClick={() => handleChatNavigation(chef.username)} class="fa-solid fa-message fa-2xl text-ddGreen cursor-pointer"></i>
                </div>}
                </div>
            </div>
            )}

        <div className='flex w-full flex-wrap px-[17rem]'>
        {chefRecipes && (
            chefRecipes.map((item, index) => (
                <div key={item.id} onClick={() => handleNavigation(item.id)} className='min-w-[300px] shadow-xl flex flex-col my-4 mr-[8px] rounded-[1rem] hover:scale-105 duration-300 cursor-pointer text-ddWhite'>
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
                  <p className='text-s'>by <span className='font-bold text-ddGreen hover:underline'>{item.poster.username}</span></p>
                  <div className='border border-ddGrey2 mx-2'></div>
                  <p className='font-bold text-ddGreen'>{getTimeAgo(item.creationTime)} <span className='text-white font-medium'>ago</span></p>
                </div>
              </div>
            </div>
            ))
        )}
        </div>
        
    </section>
  );
  
}

export default Profile;
