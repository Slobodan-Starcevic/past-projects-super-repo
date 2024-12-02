import {GET} from "./api.jsx";

export const getBuildings = async () => {
    try {
        const response = await GET(`buildings`);
        return response;
    } catch (error) {
        throw error;
    }
};