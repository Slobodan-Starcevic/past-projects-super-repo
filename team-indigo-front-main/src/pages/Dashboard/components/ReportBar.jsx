import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {faChevronRight} from '@fortawesome/free-solid-svg-icons'

function ReportBar({onClick, incidentId, reporter, incidentType, IncidentSeverity, date, status, building}) {
  return (
    <tr onClick={onClick} className="flex items-center cursor-pointer font-thin text-gray-500 even:bg-white odd:bg-[#F6F6F6] min-h-[100px] hover:bg-[#ECECEC] last:border-b-0">
        <td className="w-[10%] text-center pl-2 py-[0.5rem]">{incidentId}</td>
        <td className="w-[15%] text-left pl-2 py-[0.5rem]">{reporter}</td>
        <td className="w-[20%] text-left pl-2 py-[0.5rem]">{incidentType}</td>
        <td className="w-[10%] text-left pl-2 py-[0.5rem]">{IncidentSeverity}</td>
        <td className="w-[15%] text-left pl-2 py-[0.5rem]">{building}</td>
        <td className="w-[10%] text-left pl-2 py-[1rem]">{date}</td>
        <td className="w-[10%] text-left pl-2 py-[0.5rem]">{status}</td>
        <td className='w-[10%] flex pl-2 justify-center'>
          <FontAwesomeIcon icon={faChevronRight} style={{}} />
        </td>
        
    </tr>
  )
}

export default ReportBar