import {GET} from "../api.jsx";

export const getCalendarStatisticsMonth = async (period) => {
    try {

        const response = await GET(`statistic/calendar?period=${period}`);
        return response;
    } catch (error) {
        console.error('Error fetching statistic:', error);
        throw error;
    }
};
