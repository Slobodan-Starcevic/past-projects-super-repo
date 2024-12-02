import {POST} from "./api.jsx";


export const postFormFull = async (data) => {
    try {
        const response = await POST("form", data);
        return response.data;
    } catch (error) {
        if (error.response && error.response.status === 401) {
            return "Unauthorized access.";
        } else if (error.response && error.response.status === 404) {
            return "Doctor details not found.";
        } else {
            return "Server error.";
        }
    }
};