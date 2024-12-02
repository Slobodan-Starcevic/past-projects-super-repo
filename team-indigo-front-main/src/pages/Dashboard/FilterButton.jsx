import React, { useEffect, useState, useRef } from 'react'
import Slider from '@mui/material/Slider';

function FilterButton({text, data, filterCategory, handleFilterChange, className, reset}) {
    const [isSelected, setIsSelected] = useState(false);
    const [filterChoice, setFilterChoice] = useState('');
    const [isFiltered, setIsFiltered] = useState(false);
    const [idText, setIdText] = useState('');
    const inputRef = useRef(null);

    useEffect(() => {
        document.addEventListener('click', handleClickOutside);
        return () => {
          document.removeEventListener('click', handleClickOutside);
        };
    }, []);

    useEffect(() => {
        handleRemoveFilter();
    }, [reset])

    const handleClickOutside = (event) => {
    if(inputRef.current && !inputRef.current.contains(event.target)){
        setIsSelected(false);
    }};

    const handleSwitch = () => {
        setIsSelected(!isSelected);
    };

    const handleRemoveFilter = () => {
        setIsFiltered(false);
        handleFilterChange(filterCategory, null);
    }

    const handleChoice = (choice) => {
        setFilterChoice(choice);
        handleFilterChange(filterCategory, choice);
        setIsFiltered(true);
        handleSwitch();
    };

  return (
    <>
    <div ref={inputRef} className={`relative duration-300 cursor-pointer text-black ${isSelected ? 'bg-gray-400' : 'bg-gray-200 hover:bg-slate-300'} ${className}`}>
        {isFiltered ? (
            <div onClick={handleRemoveFilter} className='flex text-black justify-center items-center w-full h-full border-b border-black'>
                <button className='w-full h-full py-2 px-4 font-semibold'>{text}: {filterChoice}</button>
                <i className="fa-solid fa-xmark mr-5 ml-[-1rem]"></i>
            </div>
        ) : (
            <button onClick={handleSwitch} className={`w-full h-full py-2 font-semibold ${filterCategory == "id" ? '' : 'text-left'}`}>{text}</button>
        )}

        {isSelected && filterCategory != "id" && 
        <div className='absolute w-full h-auto flex-col border-1 rounded-sm overflow-hidden'>
            {Object.entries(data).map(([key, value]) => (
                <div key={key} onClick={() => {if(value){handleChoice(key)}}} 
                className={`flex items-center justify-between py-[5px] duration-300 px-[1rem] bg-gray-100 ${value ? ' cursor-pointer  hover:bg-gray-300' : ' cursor-default text-gray-400'}`}>
                    <div>{key}</div>
                    <div className='text-black rounded-full w-[20px] h-[25px] flex justify-center items-center'>{value}</div>
                </div>
            ))}
        </div>
        }

        {isSelected && filterCategory == "id" && 
        <div className='absolute w-full h-auto flex-col rounded-b-[0.5rem] overflow-hidden'>
            <div className='w-full flex'>
                <input onChange={(e) => setIdText(e.target.value)} className='outline-none' type="text" value={idText} />
                <button onClick={() => {handleChoice(idText)}}>Go</button>
            </div>
        </div>
        }
    </div>
    </>
    
  )
}

export default FilterButton