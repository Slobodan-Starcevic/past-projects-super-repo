import {GET} from "../api.jsx";

export const GetSeverityStatisticMonth = async (period) => {
    try {

        const response = await GET(`statistic/severity?period=${period}`);
        return response;
    } catch (error) {
        console.error('Error fetching statistic:', error);
        throw error;
    }
};