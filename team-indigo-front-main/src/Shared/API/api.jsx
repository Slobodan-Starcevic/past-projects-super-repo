import axios from 'axios';

const BASE_URL = "http://localhost:8080";

export const PUT = async (endpoint, data) => {
    const headers = {
        'Content-Type': 'application/json',
    };

    // const token = getToken();
    // if (token) {
    //     headers['Authorization'] = 'Bearer ' + token;
    // }

    const response = await axios.put(`${BASE_URL}/${endpoint}`, data, { headers });

    return response;
};

export const POST = async (endpoint, data) => {
    const headers = {
        'Content-Type': 'application/json',
    };

    // const token = getToken();
    // if (token) {
    //     headers['Authorization'] = 'Bearer ' + token;
    // }

    const response = await axios.post(`${BASE_URL}/${endpoint}`, data, { headers });

    return response;
};

export const GET = async (endpoint, params) => {
    try {

        // const token = getToken();
        // if (token) {
        //     headers['Authorization'] = 'Bearer ' + token;
        // }


        const response = await axios.get(`${BASE_URL}/${endpoint}`, { params });
        return response.data;
    } catch (error) {
        console.error('There was a problem with the Axios operation:', error.message);
        throw error;
    }
};
