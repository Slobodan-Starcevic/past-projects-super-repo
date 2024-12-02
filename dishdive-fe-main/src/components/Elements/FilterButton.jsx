import React, { useEffect, useState, useRef } from 'react'
import Slider from '@mui/material/Slider';
import { ThemeProvider } from '@mui/material'
import {theme} from '../../utility/MUI/customTheme'
import { Rating } from '@mui/material';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import Calendar from 'react-calendar'
import 'react-calendar/dist/Calendar.css';
import '../../utility/CSS/CustomCalendar.css'
import {toPascalCase} from '../../utility/CapitalisationService'

function FilterButton({text, data, filterCategory, handleFilterChange, className}) {
    const [isSelected, setIsSelected] = useState(false);
    const [filterChoice, setFilterChoice] = useState('');
    const [isFiltered, setIsFiltered] = useState(false);
    const [sliderValue, setSliderValue] = useState(0);
    const inputRef = useRef(null);

    useEffect(() => {
        document.addEventListener('click', handleClickOutside);
        return () => {
          document.removeEventListener('click', handleClickOutside);
        };
    }, []);


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

    const handleSliderChange = (event, value) => {
        setSliderValue(value);
    }

    const handleDateChoice = (date) => {
        const formattedDate = date.toLocaleDateString('en-GB');
        handleChoice(formattedDate);
    }

  return (
    <div ref={inputRef} className={`relative cursor-pointer hover:bg-ddGrey2 text-ddWhite ${className} ${isSelected ? 'bg-ddGrey2' : 'bg-black'} `}>
        {isFiltered ? (
            <div onClick={handleRemoveFilter} className='flex text-ddGreen justify-center items-center w-full h-full border-b border-ddGreen'>
                <button className='w-full h-full py-2 px-4 font-semibold'>{text}: {filterChoice}{filterCategory == 'rating' &&<i className="fa-solid fa-star"></i>}</button>
                <i className="fa-solid fa-xmark mr-5 ml-[-1rem]"></i>
            </div>
        ) : (
            <button onClick={handleSwitch} className='w-full h-full py-2 px-4 font-semibold'>{text}</button>
        )}

        {(isSelected && filterCategory == 'recipeTag' && data) && 
        <div className='absolute w-full h-auto flex-col rounded-b-[0.5rem] overflow-hidden'>
            {Object.entries(data).map(([key, value]) => (
                <div key={key} onClick={() => {if(value){handleChoice(key)}}} 
                className={`flex items-center justify-between py-[0.5rem] px-[1.5rem] bg-ddGrey2 ${value ? ' cursor-pointer  hover:bg-black' : ' cursor-default text-ddGrey'}`}>
                    <div>{toPascalCase(key)}</div>
                    <div className='bg-ddGreen text-black rounded-full w-[20px] h-[25px] flex justify-center items-center'>{value}</div>
                </div>
            ))}
        </div>
        }

        {(isSelected && filterCategory == 'cookTime') && 
        <div className='w-full h-auto flex-col rounded-b-[0.5rem] overflow-hidden'>
            <div className={`flex-col items-center justify-between py-[5px] px-[1rem] bg-ddGrey2 cursor-pointer  hover:bg-black`}>
                <ThemeProvider theme={theme}>
                    <Slider
                    aria-label="Temperature"
                    defaultValue={0}
                    valueLabelDisplay="auto"
                    step={10}
                    marks
                    min={0}
                    max={110}
                    color='primary'
                    style={{ zIndex: 1, marginTop: '35px' }}
                    onChange={handleSliderChange}/>
                </ThemeProvider>
            </div>
            <button onClick={() => handleChoice(sliderValue)} className='bg-ddGreen w-full h-[35px] text-black font-bold'>FILTER</button>
        </div>
        }

        {(isSelected && filterCategory == 'servings') && 
        <div className='w-full h-auto flex-col rounded-b-[0.5rem] overflow-hidden'>
            <div className={`flex-col items-center justify-between py-[5px] px-[1rem] bg-ddGrey2 cursor-pointer  hover:bg-black`}>
                <ThemeProvider theme={theme}>
                    <Slider
                    aria-label="Temperature"
                    defaultValue={0}
                    valueLabelDisplay="auto"
                    step={1}
                    marks
                    min={1}
                    max={10}
                    color='primary'
                    style={{ zIndex: 1, marginTop: '35px' }}
                    onChange={handleSliderChange}/>
                </ThemeProvider>
            </div>
            <button onClick={() => handleChoice(sliderValue)} className='bg-ddGreen w-full h-[35px] text-black font-bold'>FILTER</button>
        </div>
        }



        {(isSelected && filterCategory == 'rating') && 
        <div className='w-full h-auto flex-col rounded-b-[0.5rem] overflow-hidden'>
            <div className={`flex items-center justify-center py-[5px] px-[1rem] bg-ddGrey2 cursor-pointer  hover:bg-black`}>
                <ThemeProvider theme={theme}>
                    <Rating
                    value={sliderValue}
                    emptyIcon={<StarBorderIcon style={{ color: 'white' }} fontSize='3rem'/>}
                    precision={1}
                    size='large'
                    onChange={(event, value) => handleChoice(value)}/>
                </ThemeProvider>
            </div>
        </div>
        }

        {(isSelected && filterCategory == 'creationTime') && 
        <div className='rounded-b-[0.5rem] overflow-hidden max-z-index'>
            <div className={`w-full bg-ddGrey2 cursor-pointer z-100 p-4`}>
                <Calendar
                onChange={handleDateChoice} 
                maxDate={new Date()}
                />
            </div>
        </div>
        }
    </div>
  )
}

export default FilterButton