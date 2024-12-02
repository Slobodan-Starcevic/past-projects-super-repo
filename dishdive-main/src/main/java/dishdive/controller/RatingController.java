package dishdive.controller;

import dishdive.business.RatingServiceInterface;
import dishdive.dto.rating.request.NewRatingRequest;
import dishdive.dto.rating.response.SingleRatingResponse;
import jakarta.annotation.security.RolesAllowed;
import jakarta.validation.Valid;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.UUID;

@RestController
@RequestMapping("/rating")
public class RatingController {

    private final RatingServiceInterface ratingServiceInterface;

    public RatingController(RatingServiceInterface ratingServiceInterface) {
        this.ratingServiceInterface = ratingServiceInterface;
    }

    @GetMapping("/{recipeId}")
    public ResponseEntity<List<SingleRatingResponse>> getAllRatingsByRecipeId(@PathVariable UUID recipeId) {
        List<SingleRatingResponse> response = ratingServiceInterface.getAllRatingsByRecipeId(recipeId);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @PostMapping("/create")
    public ResponseEntity<Boolean> createRating(@RequestBody @Valid NewRatingRequest requestDTO) {
        Boolean response = ratingServiceInterface.createRating(requestDTO);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @DeleteMapping("/delete/{ratingId}")
    public ResponseEntity<Boolean> deleteRating(@PathVariable UUID ratingId) {
        Boolean response = ratingServiceInterface.deleteRating(ratingId);
        return ResponseEntity.ok(response);
    }
}
