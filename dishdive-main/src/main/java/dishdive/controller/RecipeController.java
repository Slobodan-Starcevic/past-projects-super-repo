package dishdive.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import dishdive.business.RecipeServiceInterface;
import dishdive.dto.recipe.request.RecipeCreationRequest;
import dishdive.dto.recipe.response.AllRecipeResponse;
import dishdive.dto.recipe.response.SingleRecipeResponse;
import dishdive.persistence.entity.TagEnum;
import jakarta.annotation.security.RolesAllowed;
import jakarta.validation.Valid;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDateTime;
import java.util.UUID;

@RestController
@RequestMapping("/recipe")
public class RecipeController {
    private final RecipeServiceInterface recipeService;

    public RecipeController(RecipeServiceInterface recipeService) {
        this.recipeService = recipeService;
    }

    @GetMapping
    public ResponseEntity<AllRecipeResponse> getAllRecipes(
            @RequestParam(value = "page", defaultValue = "1") int page,
            @RequestParam(value = "pageSize", defaultValue = "12") int size,
            @RequestParam(value = "search", required = false) String title,
            @RequestParam(value = "creationTime", required = false) LocalDateTime creationTime,
            @RequestParam(value = "servings", required = false) Integer servings,
            @RequestParam(value = "cookTime", required = false) Integer cookTime,
            @RequestParam(value = "recipeTag", required = false) TagEnum recipeTag,
            @RequestParam(value = "rating", required = false) Integer rating) throws JsonProcessingException {
        Pageable pageable = PageRequest.of(page, size);
        AllRecipeResponse response = recipeService.getAllRecipes(pageable, title, creationTime, servings, cookTime, recipeTag, rating);
        return ResponseEntity.ok(response);
    }
    @GetMapping("/{recipeId}")
    public ResponseEntity<SingleRecipeResponse> getRecipesById(@PathVariable UUID recipeId) throws JsonProcessingException {
        SingleRecipeResponse response = recipeService.getRecipeById(recipeId);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF"})
    @PostMapping("/create")
    public ResponseEntity<SingleRecipeResponse> createRecipe(@RequestBody @Valid RecipeCreationRequest requestDTO) throws JsonProcessingException {
        SingleRecipeResponse response = recipeService.createRecipe(requestDTO);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @PutMapping("/edit/{recipeId}")
    public ResponseEntity<SingleRecipeResponse> editRecipe(@PathVariable UUID recipeId, @RequestBody @Valid RecipeCreationRequest requestDTO) throws JsonProcessingException {
        SingleRecipeResponse response = recipeService.editRecipe(recipeId, requestDTO);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @DeleteMapping("/delete/{recipeId}")
    public ResponseEntity<Boolean> deleteRecipe(@PathVariable UUID recipeId) {
        Boolean response = recipeService.deleteRecipe(recipeId);
        return ResponseEntity.ok(response);
    }


}
