import React from 'react'
import FilterButton from '../Elements/FilterButton'

function FilterBar({filterData, handleFilterChange}) {
  return (
    <>
    <section className='bg-black w-full h-[60px] flex rounded-t-[32px]'>
      <FilterButton className={'rounded-tl-[32px] w-[20%]'} text={'Max. Cook Time'} filterCategory={'cookTime'} handleFilterChange={handleFilterChange}/>
      <FilterButton className={'w-[20%]'} text={'Servings'} filterCategory={'servings'} handleFilterChange={handleFilterChange}/>
      <FilterButton className={'w-[15%]'} text={'Tag'} filterCategory={'recipeTag'} data={filterData.recipeTagCounts} handleFilterChange={handleFilterChange}/>
      <FilterButton className={'w-[20%]'} text={'Min. Rating'} filterCategory={'rating'} handleFilterChange={handleFilterChange}/>
      <FilterButton className={'rounded-tr-[32px] w-[25%]'}  text={'Upload Time'} filterCategory={'creationTime'} data={filterData.creationTimeCounts} handleFilterChange={handleFilterChange}/>
    </section>
    </>
  )
}

export default FilterBar