import { GET, POST, PUT, DELETE } from "./API";

const path = "/chef";

export const getAllChefs = async () => await GET(`${path}`);
export const getChefById = async (chefId) => await GET(`${path}/getOne/${chefId}`);
export const getChefRecipes = async (chefId) => await GET(`${path}/${chefId}/recipes`);

export const createChef = async (chefData) => await POST(`${path}/create`, chefData);
export const loginChef = async (loginData) => {
    const response = await POST(`${path}/login`, loginData);
    const token = response.data.accessToken;
    return token;
};

export const updateChefUsernameAndEmail = async (chefId, newData) => await PUT(`${path}/${chefId}`, newData);
export const updateChefPassword = async (chefId, newPasswordData) => await PUT(`${path}/${chefId}/update-password`, newPasswordData);

export const deleteChef = async (chefId) => await DELETE(`${path}/${chefId}`, chefId);