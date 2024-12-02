import React, {useState, useEffect} from 'react'
import Cards from '../components/Home/Cards'
import FilterBar from '../components/Recipes/FilterBar'
import { getAllRecipes } from '../API/recipeAPI.jsx'
import { createPopup } from '../utility/popupHandler'
import { Pagination, ThemeProvider } from '@mui/material'
import {theme} from '../utility/MUI/customTheme'
import { useParams } from 'react-router-dom'

function Recipes() {
  const {searchFilter} = useParams();
  const [memoResponse, setMemoResponse] = useState({});
  const [recipesData, setrecipesData] = useState([]);
  const [filterData, setFilterData] = useState({});
  const [startMemo, setStartMemo] = useState('');
  const [paginationData, setPaginationData] = useState({
    page: 1,
    totalPages: 1,
    totalItems: null,
    pageSize: 12
  });
  const [chosenFilters, setChosenFilters] = useState({
    creationTime: null,
    servings: null, 
    cookTime: null,
    recipeTag: null,
    rating: null
  });
  

  useEffect(() => {
    const fetchData = async () => {
      try {
        const {creationTime, servings, cookTime, recipeTag, rating} = chosenFilters;
        const { page, pageSize } = paginationData;
        let search;
        if(searchFilter){
          search = searchFilter;
        }else{
          search = null;
        }
        let response;
        const key = `${page}${search}${creationTime}${servings}${cookTime}${recipeTag}${rating}`;

        if(memoResponse[key] && startMemo > new Date().getTime()){
          console.log('memo')
          response = memoResponse[key];
        }else{
          console.log('not memo')
          console.log({
            params: {
              page,
              pageSize,
              search,
              creationTime,
              servings,
              cookTime,
              recipeTag,
              rating
            }
          })
          response = await getAllRecipes({
            params: {
              page,
              pageSize,
              search,
              creationTime,
              servings,
              cookTime,
              recipeTag,
              rating
            }
          });
          console.log(response.data)
          if(Object.keys(memoResponse).length == 5){
            const array1 = Object.entries(memoResponse);
            array1.pop();
            const array2 = Object.fromEntries(array1);
            setMemoResponse(array2);
          }
          if(!startMemo){
            const now = new Date();
            setStartMemo(new Date(now.getTime() + 5 * 60000));
          }
          setMemoResponse((prevMemoResponse) => ({
            ...prevMemoResponse,
            [key]: response
          }));
        }

        setrecipesData(response.data.recipes);
        setPaginationData({
          page: response.data.page,
          totalPages: response.data.totalPages,
          totalItems: response.data.totalItems
        });
        setFilterData(response.data.filterCounts);
      } catch (error) {
        createPopup("error", error.message);
      }
    };
  
    fetchData();
  }, [chosenFilters, paginationData.page]);

  function handlePageClick(event, value){
    setPaginationData((prevPaginationData) => ({
      ...prevPaginationData,
      page: value,
      pageSize: 12,
    }));
  };

  const handleFilterChange = (category, chosenFilter) => {
    setChosenFilters((prevChosenFilter) => ({
      ...prevChosenFilter,
      [category]: chosenFilter
    }));
  };

  return (
    <section className='bg-gradient-to-b from-[#1b1b1b] to-black w-full flex justify-center py-[2rem]'>
      <div className='flex-col max-w-[1240px] w-full'>
        <FilterBar filterData={filterData} handleFilterChange={handleFilterChange}/>
        <Cards recipes={recipesData}/>
        <div className='flex justify-center'>
          <ThemeProvider theme={theme}>
            <Pagination
              count={paginationData.totalPages}
              page={paginationData.page}
              boundaryCount={1}
              color='primary'
              size='large'
              onChange={handlePageClick}
            />
          </ThemeProvider>
        </div>
      </div>
    </section>
  )
}

export default Recipes