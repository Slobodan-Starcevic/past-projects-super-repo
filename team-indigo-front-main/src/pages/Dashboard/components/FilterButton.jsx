import React, { useState, useEffect, useRef } from 'react'
import Input from '../../../Shared/ui/Input';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faChevronCircleDown} from '@fortawesome/free-solid-svg-icons'
import FilterCheckBox from './FilterCheckBox';

function FilterButton({name, width, filterOptions, onFilterSelect}) {
  
  const [isSelected, setIsSelected] = useState(false);
  const [isHovered, setIsHovered] = useState(false);
  const [isFiltered, setIsFiltered] = useState(false);
  const inputRef = useRef(null);

  useEffect(() => {
    document.addEventListener('click', handleClickOutside);

    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, []);

  const handleClick = (e) => {
    e.stopPropagation();
    setIsSelected(true);
  }

  const handleHover = (bool)=>{
    setIsHovered(bool);
  }

  const handleClickOutside = (event) => {
    if(inputRef.current && !inputRef.current.contains(event.target)){
      setIsSelected(false);
      setIsHovered(false);
    }
  };

  const handleFilterSelect = (selectedOption) => {
    setIsFiltered(!isFiltered);
    onFilterSelect(selectedOption);
  }

  return (
    <div ref={inputRef} className={`w-[${width}]`}>
      {isSelected ? (
        <div className='relative'>
          <Input className='h-[30px] mr-[-10px]' placeholder={`Search ${name}`}/>
          <div className='absolute w-full bg-blue-200 h-auto'>
              <div className='bg-gray-100 flex p-2'>
                <FilterCheckBox options={filterOptions} onSelectOption={handleFilterSelect}/>
              </div>
          </div>
        </div>
      ):(
        <button 
        onMouseEnter={() => handleHover(true)}
        onMouseLeave={() => handleHover(false)}
        onClick={handleClick} 
        className=' hover:bg-main-blue hover:text-white text-left pl-[1rem] py-1.5 w-full flex items-center'>
          {name}
          {isHovered && <FontAwesomeIcon icon={faChevronCircleDown} style={{marginLeft: "auto", marginRight: "10px",}} />}
        </button>
      )}
    </div>
  );
}

export default FilterButton