import React, { useState, useEffect } from 'react'
import Single from '../assets/single.png'

function Cards() {
  const [data, setData] = useState({allRecipes: [] });
  const [error, setError] = useState(null);

  useEffect(() => {
    async function fetchData() {
      try{
        const response = await fetch('http://localhost:8080/recipe');
        if(!response.ok){
          throw new Error('Response was not ok');
        }
        const result = await response.json();
        setData(result);
      }
      catch(error){
        setError(error.message)
      }
    }
    fetchData();
  }, []);

  function getTimeAgo(creationDate) {
    const currentDate = new Date();
    const created = new Date(creationDate);
  }

  return (
    <div className='w-full py-[10rem] px-4 bg-white black-font'>
      <div className='max-w-[1240p] mx-auto grid md:grid-cols-3 gap-8'>
        {error ? (
          <div>Error: {error}</div>
        ) : (
          data.allRecipes.map((item, index) => (
            <div key={index} className='w-full shadow-xl flex flex-col p-4 my-4 rounded-lg hover:scale-105 duration-300'>
              <h2 className='text-2xl font-bold text-center py-8'>{item.title}</h2>
              <p className='text-center text-4xl font-bold'>{item.poster.username}</p>
              <p>{item.creationDate}</p>
            </div>
          ))
        )}
      </div>
    </div>
  );
}

export default Cards