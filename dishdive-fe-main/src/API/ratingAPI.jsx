import { GET, POST, PUT, DELETE } from "./API";

const path = "/rating";

export const getAllRatingsByRecipeId = async (recipeId) => await GET(`${path}/${recipeId}`);

export const createRating = async (ratingData) => await POST(`${path}/create`, ratingData);

export const deleteRating = async (ratingId) => await DELETE(`${path}/delete/${ratingId}`);