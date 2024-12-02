import {POST} from "./api.jsx";


export const postBuilding = async (data) => {
    try {
        const response = await POST("buildings", data);
        return response;
    } catch (error) {
        throw error
    }
};