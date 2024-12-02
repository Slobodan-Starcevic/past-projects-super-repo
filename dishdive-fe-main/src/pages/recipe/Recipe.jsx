import React, { useEffect, useState } from 'react'
import { deleteRecipe, getRecipeById, updateRecipe } from '../../API/recipeAPI';
import { useParams } from 'react-router';
import ReactLoading from "react-loading";
import RecipeBody1 from './RecipeBody1';
import TextArea from '../../components/Elements/TextArea';
import Button from '../../components/Elements/Button';
import { Rating } from '@mui/material';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import { createPopup } from '../../utility/popupHandler';
import { createRating, deleteRating, getAllRatingsByRecipeId } from '../../API/ratingAPI';
import useAuthStore from '../../utility/auth/authStore';
import {isLoggedIn} from '../../utility/AuthorizationCheck'
import { useNavigate } from 'react-router-dom';
import {gramsConvertor} from '../../utility/gramsConvertor'
import RecipeEdit from './RecipeEdit'

function Recipe() {
  const navigate = useNavigate();
  const { user } = useAuthStore();
  const { id } = useParams();
  const [recipe, setRecipe] = useState();
  const [ratings, setRatings] = useState();
  const [yourRating, setYourRating] = useState(null);
  const [ratingError, setRatingError] = useState();
  const [renderSwitch, setRenderSwitch] = useState(false);
  const [rating, setRating] = useState({
    score: null,
    comment: ""
  });
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        
        const recipeResponse = await getRecipeById(id);
        const ratingResponse = await getAllRatingsByRecipeId(id);
        setRecipe(recipeResponse.data);
        setRatings(ratingResponse.data);
        if(user){
          const userId = user.userId;
          setYourRating(() => ratingResponse.data.find((rating) => rating.rater.id === userId) || null);
        }
      } catch (error) {
        console.error(error);
      }
    };
  
    fetchData();
  }, [renderSwitch]);
  

  const handleRatingPost = async () => {
    try {
      if(!user){
        navigate('/login');
        createPopup('error', "Log in required for rating")
      }else if(rating.score !== null){
        const posterId = user.userId;
        const recipeId = recipe.id;
        const {score, comment} = rating;
        const response = await createRating({posterId, score, comment, recipeId});
        if(response){
          setRenderSwitch(!renderSwitch);
          createPopup("succes", "Rating created succesfully");
        }else{
          createPopup("error", "Something went wrong, try again later")
        }
      }else{
        createPopup('error', "Score required")
        setRatingError('Rating required')
      }
    } catch (error) {
      createPopup("error", error.message);
    }
  }

  const handleCommentDelete = async (ratingId) => {
    try {
      const response = await deleteRating(ratingId);
      if(response.data){
        setRating({
          score: null,
          comment: ""
        });
        setRenderSwitch(!renderSwitch);
        createPopup("succes", "Rating deleted succesfully");
      }else{
        createPopup("error", "Error deleting comment")
      }
    } catch (error) {
      createPopup("error", error.message);
    }
  }

  const handlePostDelete = async (recipeId) => {
    try {
      const response = await deleteRecipe(recipeId);
      if(response.data){
        navigate('/', { replace: true });
        createPopup("succes", "Recipe deleted succesfully");
      }else{
        createPopup("error", "Error deleting comment")
      }
    } catch (error) {
      createPopup("error", error.message);
    }
  }

  const handleEditSwitch = () => {
    setIsEditing(!isEditing);
  };

  const handleEditPost = async(editedRecipeData) => {
    try {
      if(isLoggedIn == false){
        navigate('/login');
        createPopup('error', "Log in required for editing")
      }else if(editedRecipeData){
        const recipeId = recipe.id;
        const response = await updateRecipe(recipeId, editedRecipeData);
        handleEditSwitch();
        setRenderSwitch(!renderSwitch);
        createPopup("succes", "Post edited succesfully");
      }else{
        createPopup('error', "Score required")
        setRatingError('Rating required')
      }
    } catch (error) {
      createPopup("error", error.message);
    }
  };

  return (
    <div className='relative'>
      {isEditing && (
      <div className='absolute h-full w-full flex justify-center'>
        <div onClick={handleEditSwitch} className='absolute bg-[#00000088] h-full w-full z-0' />
        <div onClick={(e) => e.stopPropagation()} className='relative'>
          <RecipeEdit recipe={recipe} handleEditPost={handleEditPost}/>
        </div>
      </div>
    )}
      {recipe ? (
        <section className='bg-gradient-to-b from-[#1b1b1b] to-black py-10'>
            <RecipeBody1 recipe={recipe} handlePostDelete={handlePostDelete} handleEditSwitch={handleEditSwitch} isEditing={isEditing}/>
          <div className='flex justify-center max-w-[1240px] mx-auto  py-10 px-[5rem] bg-ddInputBg'>
            <div className='flex-[50%]'>
              <p className='font-bold text-3xl mb-3 text-ddGreen'>Description</p>
              <p>{recipe.description}</p>
            </div>
            <div className='flex-[50%] pl-[5rem]'>
              <p className='font-bold text-3xl mb-3 text-ddGreen'>Ingredients</p>
              {recipe.ingredients.map((ingredient, index) => (
                <p className='ml-3 text-lg' key={index}><span className='font-bold text-2xl'>{gramsConvertor(ingredient.amount)}</span> - {ingredient.name}</p>
              ))}
            </div>
          </div>
          <div className='flex-col justify-center max-w-[1240px] mx-auto bg-black py-10 px-[15rem]'>
            
          {!isEditing &&
          <>
          <div className='flex-col flex-[50%] pb-5'>
            {!yourRating ? (
              <div>
                <p className='font-bold text-3xl mb-3 text-ddGreen'>Rate this dish</p>
                <Rating
                  value={rating.score}
                  emptyIcon={<StarBorderIcon style={{ color: 'white' }} fontSize='3rem'/>}
                  precision={1}
                  size='large'
                  onChange={(event, value) => setRating((prevrating) => ({...prevrating, score: value}))}
                />
                {ratingError && <span className='flex mb-[12px] mt-[-5px] text-ddRed'>{ratingError}</span>}
                <TextArea placeholder={"Comment (optional)"} onChange={(e) => setRating((prevrating) => ({...prevrating, comment: e.target.value}))}/>
                <Button text={"Post rating"} onClick={handleRatingPost}/>
              </div>
            ) : (
              <div>
                <p className='font-bold text-3xl mb-3 text-ddGreen'>Your rating</p>
                <div className='relative flex-col bg-ddInputBg p-4 rounded-[1rem] mb-3'>
                  <div className='flex items-center space-x-2 pb-2'>
                    <i className="fa-solid fa-user text-ddGreen"></i>
                    <p>You</p>
                    <i onClick={() => handleCommentDelete(yourRating.id)} className=" cursor-pointer fa-solid fa-trash flex  absolute right-0 p-10 text-ddGreen"></i>
                  </div>
                  <Rating
                  value={yourRating.score}
                  emptyIcon={<StarBorderIcon style={{ color: 'white' }} />}
                  readOnly
                  />
                  <div>{yourRating.comment}</div>
                </div>
              </div>
            )}
          </div>


           <div className='flex-col flex-[50%]'>
            <p className='font-bold text-3xl mb-3 text-ddGreen'>All ratings</p>
            {ratings ? (ratings.map((rating) => (
              <div key={rating.id} className='relative flex-col bg-ddInputBg p-4 rounded-[1rem] mb-3'>
                <div className='flex items-center space-x-2 pb-2'>
                  <i className="fa-solid fa-user text-ddGreen"></i>
                  <p>{rating.rater.username}</p>
                  {user && (user.userId == rating.rater.id || user.role == "ADMIN") && <i onClick={() => handleCommentDelete(rating.id)} className="cursor-pointer fa-solid fa-trash flex  absolute right-0 p-10 text-ddGreen"></i>}
                </div>
                <Rating
                value={rating.score}
                emptyIcon={<StarBorderIcon style={{ color: 'white' }} />}
                readOnly
                />
                {rating.comment && <div>{rating.comment}</div>}
              </div>
            ))) : (
              <div>Be the first to rate this dish!</div>
            )}
          </div>
          </>}
        </div>
        </section>
      ) : (
        <div className='flex justify-center items-center'>
          <ReactLoading type='bubbles' width={'10%'}/>
        </div>
      )}
    </div>
  )
}

export default Recipe