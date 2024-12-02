import React, { useState, useCallback, useEffect } from 'react'
import Input from '../components/Elements/Input'
import Button from '../components/Elements/Button'
import { createRecipe } from '../API/recipeAPI'
import useAuthStore from '../utility/auth/authStore'
import { useNavigate } from 'react-router-dom'
import { createPopup } from '../utility/popupHandler'
import Dropdown from '../components/Elements/DropDown'
import TextArea from '../components/Elements/TextArea'
import InputAdd from '../components/Elements/InputAdd'

function Create() {
    const {user} = useAuthStore();
    const navigate = useNavigate();
    const [recipeData, setRecipeData] = useState({
        title: '',
        description: '',
        servings: '',
        prepTime: '',
        cookTime: '',
        recipeTag: '',
        ingredients: []
    });
    const [validationErrors, setValidationErrors] = useState({
        title: '',
        description: '',
        servings: '',
        prepTime: '',
        cookTime: '',
        recipeTag: '',
        ingredients: ''
  });

    useEffect(() => {
      if(!user){
        createPopup('error', "Please login to post")
        navigate('/login');
      }
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setRecipeData((prevRecipeData) => ({
            ...prevRecipeData,
            [name]: value
        }))

        validateInput(name, value);
    }

    const handleSubmit = () => {
        const {title, description, servings, prepTime, cookTime, recipeTag, ingredients} = recipeData;
        const creationTime = new Date();
        const userId = user.userId;

        const allValidationErrorsEmpty = Object.values(validationErrors).every(value => value === '');
        const someRecipeDataEmpty = Object.values(recipeData).some(value => value === '');

        if(!someRecipeDataEmpty && allValidationErrorsEmpty){
          createRecipe({userId , title, description, creationTime: creationTime, servings, prepTime, cookTime, recipeTag, ingredients})
        .then((response) => {
          if(response){
            const recipeId = response.data.id;
            navigate(`/recipe/${recipeId}`, {replace: true});
            createPopup("succes", "Recipe creation succesful")
          }
        })
        .catch(error => createPopup("error", error.message));
      } else {
          validateInput("title", title);
          validateInput("description", description);
          validateInput("servings", servings);
          validateInput("prepTime", prepTime);
          validateInput("cookTime", cookTime);
          validateInput("recipeTag", recipeTag);
          validateInput("ingredients", ingredients);
          createPopup("error", "Invalid data")
      }
    };

    const handleIngredientChange = (ingredientList) => {
      setRecipeData((prevRecipeData) => ({
        ...prevRecipeData,
        ingredients: ingredientList
    }))
      validateInput("ingredients", ingredientList);
    }

    const validateInput = (name, value) => {
      let error = '';

      switch(name){
          case 'title': 
              if (!value.trim()) {
                  error = 'Title is required';
              }else if(value.length < 3) {
                  error = 'Title must be at least 3 characters';
              }else if(value.length > 50){
                  error = 'Title may be at most 20 characters';
              }
              break;
          case 'description':
              if (!value.trim()) {
                  error = 'Description is required';
              } else if (value.length < 5) {
                  error = 'Description must be at least 5 characters';
              }else if(value.length > 500){
                error = 'Description may be at most 500 characters';
              }
              break;
          case 'servings':
              const intValue = parseInt(value, 10);
              if (!value.trim()) {
                  error = 'Servings amount is required';
              }else if (!/^\d+$/.test(intValue)) {
                error = 'Enter a valid numbers only';
              }else if (isNaN(intValue) || intValue <= 0) {
                error = 'Enter a positive number';
              }
              break;
          case 'prepTime':
            const intValue2 = parseInt(value, 10);
            if (!value.trim()) {
                error = 'Prep time amount is required';
            }else if (!/^\d+$/.test(intValue2)) {
              error = 'Enter a valid numbers only';
            }else if (isNaN(intValue2) || intValue2 <= 0) {
              error = 'Enter a positive number';
            }
            break;
          case 'cookTime':
            const intValue3 = parseInt(value, 10);
            if (!value.trim()) {
                error = 'Cooking time amount is required';
            }else if (!/^\d+$/.test(intValue3)) {
              error = 'Enter a valid numbers only';
            }else if (isNaN(intValue3) || intValue3 <= 0) {
              error = 'Enter a positive number';
            }
            break;
          case 'recipeTag':
              if (!value.trim()) {
                  error = 'Tag is required';
              }
              break;
          case 'ingredients':
              if (value.length < 2) {
                  error = 'Atleast 2 ingredient is required';
              }else if (!value.every(object => Object.values(object).every(value => value !== ''))) {
                error = 'All ingredients and amounts must be filled in';
              }
              break;
          default:
      }

      setValidationErrors((prevValidationErrors)=>({
          ...prevValidationErrors,
          [name]: error
      }));
  };

  return (
    <section className='bg-gradient-to-b from-[#1b1b1b] to-black w-full flex py-[1rem]'>
      <div className='w-[1240px] black-bg flex flex-row mx-auto p-8 rounded-[2rem] shadow-lg space-x-[3rem]'>
        <div className='w-full flex-col'>
            <Input label={"Title"} type="text" name='title' onChange={handleInputChange} />
            {validationErrors.title && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.title}</span>}
            <Input label={"Servings"} type="number" name='servings' onChange={handleInputChange} />
            {validationErrors.servings && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.servings}</span>}
            <Input label={"Preparation time"} type="number" name='prepTime' onChange={handleInputChange} />
            {validationErrors.prepTime && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.prepTime}</span>}
            <Input label={"Cooking time"} type="number" name='cookTime' onChange={handleInputChange} />
            {validationErrors.cookTime && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.cookTime}</span>}
            <Dropdown label={"Tag your recipe"} type="text" name='recipeTag' onChange={handleInputChange}/>
            {validationErrors.recipeTag && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.recipeTag}</span>}
            <Button text={"Create Dish"} onClick={handleSubmit}/>
        </div>
        <div className='w-full flex-col'>
            <TextArea label={"Description"} type="text" name='description' onChange={handleInputChange} />
            {validationErrors.description && <span className='flex mb-[12px] mt-[-12px] text-ddRed'>{validationErrors.description}</span>}
            <InputAdd label={"Ingredients"} type="text" name='ingredients' onChange={handleIngredientChange} />
            {validationErrors.ingredients && <span className='flex mt-[-50px] text-ddRed'>{validationErrors.ingredients}</span>}
        </div>
      </div>
    </section>
  )
}

export default Create;