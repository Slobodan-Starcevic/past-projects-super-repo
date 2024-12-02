import {GET} from "../api.jsx";

export const getTypeStatisticMonth = async (period) => {
    try {

        const response = await GET(`statistic/type?period=${period}`);
        return response;
    } catch (error) {
        console.error('Error fetching statistic:', error);
        throw error;
    }
};
