import React from 'react'
import ReportBar from '../Dashboard/components/ReportBar'
import { CircularProgress } from '@mui/material'

function Forms({forms, handleChoice}) {
  return (
    <>
        {forms ? (
        <div className="overflow-x-auto">
            <table className="min-w-full">
            <tbody>
            {forms.map((incident) => (
                <ReportBar
                    key={incident.id}
                    onClick={() => handleChoice(incident)}
                    incidentId={incident.id}
                    reporter={incident.employeeName}
                    incidentType={incident.type.join(', ')}
                    IncidentSeverity={incident.severity}
                    date={incident.date}
                    status={incident.status}
                    building={incident.building}/>
            ))}
            </tbody>
            </table>
        </div>
    ): (<div className="my-5">
            <CircularProgress/>
        </div>)}
    </>
  )
}

export default Forms