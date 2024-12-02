import axios from 'axios';

const fetchData = async (url) => {
    try {
        const response = await axios.get(`http://localhost:8080${url}`);
        if(!response.ok){
            throw new Error(`Failed to fetch data from ${url}. Status: ${response.status}`)
        }
        return response.data;
    }
    catch(error){
        console.error('Error:', error)
        throw error;
    }
};
const formAPI = {
    getAllForms: () => fetchData("/form"),
    // getFakeData: () => Promise.resolve(fakeData),
};


export default formAPI;