import {GET} from "./api.jsx";

export const getFormsList = async (queryParams) => {
    try {
        let apiQuery = "?";

        if (queryParams.has('name')) {
            apiQuery += `name=${queryParams.get('name')}&`;
        }

        const page = queryParams.get('page') || '0';
        apiQuery += `page=${page - 1}`;

        const response = await GET(`form${apiQuery}`);
        return response;
    } catch (error) {
        console.error('Error fetching doctors:', error);
        throw error;
    }
};
