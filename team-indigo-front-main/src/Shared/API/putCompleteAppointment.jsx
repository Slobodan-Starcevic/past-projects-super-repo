import { PUT} from "./api.jsx";

export const putCompleteAppointment = async (id) => {
    try {
        const response = await PUT(`form/${id}/complete`);
        return response;
    } catch (error) {
        throw error
    }
};