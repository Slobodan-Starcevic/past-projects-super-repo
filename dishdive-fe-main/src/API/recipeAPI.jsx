import { GET, POST, PUT, DELETE } from "./API";
import axiosInstance from "../utility/axios/axiosInstance";

const path = "/recipe";

//GET
export const getAllRecipes = async ({params}) => await axiosInstance.get(`${path}`, {params});
export const getRecipeById = async (recipeId) => await axiosInstance.get(`${path}/${recipeId}`);

//POST
export const createRecipe = async (recipeData) => await POST(`${path}/create`, recipeData);

//PUT
export const updateRecipe = async (recipeId, updatedData) => await PUT(`${path}/edit/${recipeId}`, updatedData);

//DELETE
export const deleteRecipe = async (recipeId) => await DELETE(`${path}/delete/${recipeId}`);