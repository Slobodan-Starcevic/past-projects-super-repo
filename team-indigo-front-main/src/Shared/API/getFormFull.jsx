import {GET} from "./api.jsx";


export const getFormFull = async (id) => {
    try {
        const response = await GET(`form/${id}`);
        return response;
    } catch (error) {
        console.error('Error fetching form:', error);
        throw error;
    }
};