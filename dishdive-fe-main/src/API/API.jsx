import axiosInstance from "../utility/axios/axiosInstance";
import { createPopup } from "../utility/popupHandler";

const jsonHeader = {
    'Content-Type': 'application/json',
};

const handleResponse = (response) => {
    if (!response || response.status < 200 || response.status >= 300) {
      throw new Error(`${response.status} Server Error`);
    }
    return response;
};

const handleError = (error) => {
    createPopup("error", error.message);
    throw error;
};

export const GET = async (path) => {
    try{
        const response = await axiosInstance.get(`${path}`);
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
}

export const POST = async (path, data) => {
    try{
        const response = await axiosInstance.post(`${path}`, data, { jsonHeader });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
}

export const PUT = async (path, data) => {
    try{
        const response = await axiosInstance.put(`${path}`, data, { jsonHeader });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
}

export const DELETE = async (path, data) => {
    try{
        const response = await axiosInstance.delete(`${path}`, data, { jsonHeader });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
}