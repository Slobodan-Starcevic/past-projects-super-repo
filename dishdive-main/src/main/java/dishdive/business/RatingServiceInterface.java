package dishdive.business;

import dishdive.dto.rating.request.NewRatingRequest;
import dishdive.dto.rating.response.SingleRatingResponse;

import java.util.List;
import java.util.UUID;

public interface RatingServiceInterface {
    List<SingleRatingResponse> getAllRatingsByRecipeId(UUID recipeId);
    Boolean createRating(NewRatingRequest newRating);
    Boolean deleteRating(UUID ratingId);

}
