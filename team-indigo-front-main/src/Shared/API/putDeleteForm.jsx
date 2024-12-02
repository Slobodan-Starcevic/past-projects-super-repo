import { PUT} from "./api.jsx";

export const putDeleteForm = async (id) => {
    try {
        const response = await PUT(`form/${id}/delete`);
        console.log(response)
        return response;
    } catch (error) {
        throw error;;
    }
};