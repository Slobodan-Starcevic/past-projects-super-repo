export const transformDataGraph = (rawData, period) => {
    let transformedData = [];

    period = period === "All Time" ? "allTime" : period === "1 Year" ? "year" : period === "1 Month" ? "month" : "week";

    if (period === 'year') {
        transformedData = Array.from({ length: 12 }, (_, i) => {
            return {
                date: `${i + 1}/2023`,
                "incidents": 0,
            };
        });

        rawData.dates.forEach(day => {
            const monthIndex = parseInt(day.name.split('/')[0]) - 1;
            transformedData[monthIndex].incidents += day.incidents;
        });
    } else if (period === 'month') {
        const currentDate = new Date();
        transformedData = Array.from({ length: 30 }, (_, i) => {
            const date = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() - (30 - i));

            const formattedDay = date.getDate().toString().padStart(2, '0');
            const formattedMonth = (date.getMonth() + 1).toString().padStart(2, '0');

            return {
                date: `${formattedDay}/${formattedMonth}`,
                "incidents": 0,
            };
        });


        rawData.dates.forEach(day => {
            console.log(day.name)
            console.log(transformedData)
            let index = transformedData.findIndex(item => item.date === day.name)
            console.log(index)
            if (index !== -1) {
                transformedData[index].incidents += day.incidents;
            }
        });
    } else if (period === 'week') {
        const todayIndex = new Date().getDay();
        const weekdayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

        const orderedWeekdayNames = [
            ...weekdayNames.slice(todayIndex),
            ...weekdayNames.slice(0, todayIndex)
        ];

        transformedData = orderedWeekdayNames.map(weekday => {
            return {
                date: weekday,
                "incidents": 0,
            };
        });

        rawData.dates.forEach(day => {
            const [dayPart, monthPart] = day.name.split('/');
            const date = new Date(new Date().getFullYear(), monthPart - 1, dayPart);

            const weekdayIndex = date.getDay();
            transformedData[weekdayIndex].incidents += day.incidents;
        });
    } else {
        let lastDate = rawData.dates[0].name;
        let [lastMonth, lastYear] = lastDate.split('/').map(num => parseInt(num));

        const currentDate = new Date();
        const currentMonth = currentDate.getMonth() + 1;
        const currentYear = currentDate.getFullYear();

        console.log(lastYear + " " +lastMonth)

        while (lastYear < currentYear || (lastYear === currentYear && lastMonth <= currentMonth)) {
            transformedData.push({
                date: `${lastMonth}/${lastYear}`,
                "incidents": 0,
                "incidentsColor": `hsl(${Math.floor(Math.random() * 360)}, 70%, 50%)`
            });

            lastMonth++;
            if (lastMonth > 12) {
                lastMonth = 1;
                lastYear++;
            }
        }

        rawData.dates.forEach(item => {
            const [month, year] = item.name.split('/');
            const index = transformedData.findIndex(item => item.date === `${month}/${year}`);
            if (index !== -1) {
                transformedData[index].incidents += item.incidents;
            }
        });
    }

    return transformedData;
};

export const transformDataPie = (rawData) => {
    const generateColor = () => `hsl(${Math.floor(Math.random() * 360)}, 70%, 50%)`;

    return rawData.types.map((type, index) => ({
        id: type.name,
        label: type.name,
        value: type.incidents,
        color: generateColor()
    }));
};