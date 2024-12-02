import React, { useEffect, useState } from 'react';
import Input from './Input';
import { createPopup } from '../../utility/popupHandler';

function InputAdd({ onChange, value, render}) {
  const [ingredientList, setIngredientList] = useState([]);

  useEffect(() => {
    if(ingredientList.length === 0){
        setIngredientList([{ name: '', amount: '' }]);
    }
    if(ingredientList != value){
      onChange(ingredientList);
    }
  }, [ingredientList])
  
  const handleInputChange = (index, fieldName, fieldValue) => {
    const newIngredientList = [...ingredientList];
    newIngredientList[index][fieldName] = fieldValue;
    setIngredientList(newIngredientList);
  };

  const handleAddition = () => {
    const allFilled = ingredientList.every(item => Object.values(item).every(value => value !== ''));

    if (allFilled) {
        setIngredientList([...ingredientList, { name: '', amount: '' }]);
    } else {
        createPopup("error", "Fill in all fields before adding more ingredients");
    }
    };

    const handleDelete = (index) => {
        setIngredientList((prevIngredientList) => {
          const updatedIngredientList = prevIngredientList.filter((_, i) => i !== index);
          return updatedIngredientList;
        });

      };
  

  return (
    <>
    <div className='flex'>
        <p className='w-full font-bold text-sm mb-[0.5rem]'>Ingredient</p>
        <p className='w-[200px] font-bold text-sm mb-[0.5rem]'>Amount in grams</p>
        <div className='w-[60px]'/>
    </div>
      {ingredientList.map((ingredient, index) => (
        <div key={index} className='flex w-full mb-4'>
            <Input
                type="text"
                name={`ingredient-${index}`}
                value={ingredient.name}
                onChange={(e) => handleInputChange(index, 'name', e.target.value)}
                className={'w-full pr-5'}
            />
            <Input
                type="number"
                name={`amount-${index}`}
                value={ingredient.amount}
                onChange={(e) => handleInputChange(index, 'amount', e.target.value)}
                className={'w-[200px]'}
            />
            <div className=''>
                <i className="fa-solid fa-trash cursor-pointer text-ddGreen p-4" onClick={() => handleDelete(index)}/>
            </div>
        </div>
      ))}
      <i className="fa-solid fa-plus fa-lg ml-2 text-ddGreen cursor-pointer" onClick={handleAddition}></i>
    </>
  );
}

export default InputAdd;
