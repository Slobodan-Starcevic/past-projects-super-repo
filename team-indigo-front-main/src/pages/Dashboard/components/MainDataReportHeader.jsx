import React from "react";

const MainDataReportHeader = ({ data }) => {
    if (!data) return null;

    return (
        <table className='table-auto w-full text-left mb-5 mt-3 text-sm'>
            <tbody>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>ID</td>
                <td className='px-4 py-2'>{data.id || 'N/A'}</td>
            </tr>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>Status</td>
                <td className='px-4 py-2'>{data.status || 'N/A'}</td>
            </tr>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>Type</td>
                <td className='px-4 py-2'>{data.type?.join(', ') || 'N/A'}</td>
            </tr>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>Severity</td>
                <td className='px-4 py-2'>{data.severity || 'N/A'}</td>
            </tr>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>Employee Name</td>
                <td className='px-4 py-2'>{data.employeeName || 'N/A'}</td>
            </tr>
            <tr className='border-b'>
                <td className='px-4 py-2 font-medium'>Date</td>
                <td className='px-4 py-2'>{data.date || 'N/A'}</td>
            </tr>
            </tbody>
        </table>
    );
};

export default MainDataReportHeader;