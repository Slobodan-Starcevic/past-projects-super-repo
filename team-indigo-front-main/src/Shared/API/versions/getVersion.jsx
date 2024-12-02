import {GET} from "../api.jsx";


export const getVersion = async (id, version) => {
    try {
        if (version === "latest"){
            const response = await GET(`form/${id}`);
            return response;
        }
        const response = await GET(`version/${id}/version/${version}`);
        return response;
    } catch (error) {
        console.error('Error fetching form:', error);
        throw error;
    }
};