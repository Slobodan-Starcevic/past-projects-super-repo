import form from "./fakeData"

export const getWaitingReports = async () => {
    try {
        const response = form;
        return response;
    } catch (error) {
        console.error('Error fetching reports:', error);
        throw error;
    }
};