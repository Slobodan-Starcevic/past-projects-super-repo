package dishdive.business.service;


import dishdive.business.RatingServiceInterface;
import dishdive.business.exception.NotFoundException;
import dishdive.dto.rating.request.NewRatingRequest;
import dishdive.dto.rating.response.SingleRatingResponse;
import dishdive.persistence.entity.ChefEntity;
import dishdive.persistence.entity.RatingEntity;
import dishdive.persistence.entity.RecipeEntity;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RatingRepository;
import dishdive.persistence.repository.RecipeRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
public class RatingService implements RatingServiceInterface {

    private final RatingRepository ratingRepository;
    private final ChefRepository chefRepository;
    private final RecipeRepository recipeRepository;

    public RatingService(RatingRepository ratingRepository1, ChefRepository chefRepository, RecipeRepository recipeRepository) {
        this.ratingRepository = ratingRepository1;
        this.chefRepository = chefRepository;
        this.recipeRepository = recipeRepository;
    }

    @Override
    public List<SingleRatingResponse> getAllRatingsByRecipeId(UUID recipeId) {
        List<RatingEntity> entities = ratingRepository.findAllByRecipeId(recipeId);

        List<SingleRatingResponse> response = new ArrayList<>();

        for (RatingEntity entity: entities) {
            SingleRatingResponse dto = SingleRatingResponse.builder()
                    .id(entity.getId())
                    .rater(entity.getRater())
                    .score(entity.getScore())
                    .comment(entity.getComment())
                    .build();
            response.add(dto);
        }

        return response;
    }

    @Override
    public Boolean createRating(NewRatingRequest newRating) {
        Optional<ChefEntity> rater = chefRepository.findById(newRating.getPosterId());
        Optional<RecipeEntity> recipe = recipeRepository.findById(newRating.getRecipeId());
        if (rater.isEmpty() || recipe.isEmpty()) {
            throw new NotFoundException();
        }

        RatingEntity rating = new RatingEntity(UUID.randomUUID(), rater.get(), recipe.get(), newRating.getScore(), newRating.getComment());
        ratingRepository.save(rating);

        return true;
    }

    @Override
    public Boolean deleteRating(UUID ratingId) {
        Optional<RatingEntity> rating = ratingRepository.findById(ratingId);
        if (rating.isEmpty()) {
            throw new NotFoundException();
        }
        ratingRepository.delete(rating.get());

        return true;
    }
}
