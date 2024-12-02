import {GET} from "../api.jsx";


export const getVersions = async (id) => {
    try {
        const response = await GET(`version/${id}/versions`);
        return response;
    } catch (error) {
        console.error('Error fetching form:', error);
        throw error;
    }
};