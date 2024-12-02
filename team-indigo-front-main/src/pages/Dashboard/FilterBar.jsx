import React, { useState } from 'react'
import FilterButton from './FilterButton'
import ResetButton from'./ResetButton'

function FilterBar({filterData, handleFilterChange}) {
  const [resetSwitch, setResetSwitch] = useState(false);

  const handleFilterReset = () => {
    setResetSwitch(!resetSwitch);
  }
  return (
    <>
    <section className='w-full min-h-[60px] flex rounded-t-[4px]'>
      <FilterButton text={'ID'}         filterCategory={'id'}         handleFilterChange={handleFilterChange} className={'rounded-tl-[4px] w-[10%]'} reset={resetSwitch}/>
      <FilterButton text={'Reporter'}   filterCategory={'reporter'}   data={filterData.reporterCounts} handleFilterChange={handleFilterChange} className={'w-[15%]'} reset={resetSwitch}/>
      <FilterButton text={'Type'}       filterCategory={'type'}       data={filterData.incidentTypeCounts} handleFilterChange={handleFilterChange} className={'w-[20%]'} reset={resetSwitch}/>
      <FilterButton text={'Severity'}   filterCategory={'severity'}   data={filterData.severityCounts} handleFilterChange={handleFilterChange} className={'w-[10%]'} reset={resetSwitch}/>
      <FilterButton text={'Building'}   filterCategory={'building'}   data={filterData.buildingCounts} handleFilterChange={handleFilterChange} className={'w-[15%]'} reset={resetSwitch}/>
      <FilterButton text={'Date'}       filterCategory={'date'}       data={filterData.dateCounts} handleFilterChange={handleFilterChange} className={'w-[10%]'} reset={resetSwitch}/>
      <FilterButton text={'Status'}     filterCategory={'status'}     data={filterData.statusCounts} handleFilterChange={handleFilterChange} className={'w-[10%]'} reset={resetSwitch}/>
      <ResetButton text={'Reset Filters'} resetFilters={handleFilterReset} className={'rounded-tr-[4px] w-[10%]'}/>
    </section>
    </>
  )
}

export default FilterBar