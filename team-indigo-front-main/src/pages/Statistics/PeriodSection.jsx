import React, { useCallback, useState } from 'react';
import { Button } from "@mui/material";
import { debounce } from "lodash";

export default function PeriodSelector({ onSelectPeriod }) {
    const [selectedPeriod, setSelectedPeriod] = useState('All Time');

    const debouncedOnSelectPeriod = useCallback(
        debounce(onSelectPeriod, 10),
        []
    );

    const handleSelectPeriod = (period) => {
        setSelectedPeriod(period);
        debouncedOnSelectPeriod(period);
    };

    const periods = ['All Time', '1 Year', '1 Month', '1 Week'];

    return (
        <div className="p-3 flex flex-row items-center justify-center mb-3">
            <p className="text-sm md:text-lg font-thin text-dark-blue mr-3 whitespace-nowrap">Period:</p>
            {periods.map((period) => (
                <Button
                    key={period}
                    sx={{
                        borderRadius: '10px',
                        border: '1px solid #94b3d7',
                        fontSize: { xs: '0.6rem', sm: '0.75rem', md: '1rem' },
                        padding: '10px 20px',
                        margin: '0 10px',
                        backgroundColor: period === selectedPeriod ? '#1676d2' : 'transparent',
                        color: period === selectedPeriod ? 'white' : 'black',
                        '&:hover': {
                            backgroundColor: period === selectedPeriod ? '#1676d2' : 'transparent',
                            color: period === selectedPeriod ? 'white' : 'black',
                            border: '1px solid #94b3d7',
                        },
                    }}
                    onClick={() => handleSelectPeriod(period)}
                >
                    {period}
                </Button>
            ))}
        </div>
    );
}
