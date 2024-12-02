import {GET} from "./api.jsx";

export const getReportsByUser = async (queryParams, id) => {
    try {
        let apiQuery = "?";

        const page = queryParams.get('page') || '0';
        apiQuery += `page=${page - 1}`;


        const response = await GET(`form/user/${id}${apiQuery}`);
        return response;
    } catch (error) {
        console.error('Error fetching reports:', error);
        throw error;
    }
};
