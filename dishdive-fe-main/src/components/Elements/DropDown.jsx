import React, { useEffect, useState } from 'react';

function Dropdown ({label, name, onChange, value}) {
  const [selectedValue, setSelectedValue] = useState('');

  const handleChoiceChange = (e) => {
    setSelectedValue(e.target.value);
    onChange(e);
  }
  return (
    <div>
      {label && <p className='font-bold text-sm mb-[0.5rem]'>{label}</p>}
      <select className='p-3 flex w-full rounded-md text-ddWhite placeholder-ddGrey bg-ddInputBg mb-[16px] outline-none focus:ring-2 focus:ring-ddGreen hover:ring-2 hover:ring-ddGrey' 
      id="dropdown" name={name} value={value} onChange={handleChoiceChange}>
        <option value="" hidden>Choose a tag</option>
        <option value="BREAKFAST">Breakfast</option>
        <option value="LUNCH">Lunch</option>
        <option value="DINNER">Dinner</option>
        <option value="DESSERT">Dessert</option>
        <option value="SNACK">Snack</option>
      </select>
    </div>
  );
};

export default Dropdown;