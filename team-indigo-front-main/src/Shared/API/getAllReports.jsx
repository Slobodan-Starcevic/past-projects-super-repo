import {GET} from "./api.jsx";

export const getAllReports = async (params, role, name) => {
    try {
        let response;

        console.log(params)
        console.log(role)
        console.log(name)

        if(role == 'regular_staff'){
            response = await GET(`form/reporter/${name.replace(/\s+/g, '')}`, params);
        } else{
            response = await GET(`form`, params);
        }
        return response;
    } catch (error) {
        console.error('Error fetching reports:', error);
        throw error;
    }
};
