import {GET} from "./api.jsx";

export const getWaitingReports = async (queryParams) => {
    try {
        let apiQuery = "?";

        const page = queryParams.get('page') || '0';
        apiQuery += `page=${page - 1}`;


        const response = await GET(`form${apiQuery}`);
        return response;
    } catch (error) {
        console.error('Error fetching reports:', error);
        throw error;
    }
};
