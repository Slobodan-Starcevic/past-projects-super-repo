package dishdive.persistence.repository;

import dishdive.persistence.entity.RatingEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.math.BigDecimal;
import java.util.List;
import java.util.UUID;

public interface RatingRepository extends JpaRepository<RatingEntity, UUID> {

    List<RatingEntity> findAllByRecipeId(UUID recipeId);

    @Query("SELECT AVG(r.score) AS averageScore " +
            "FROM RatingEntity r " +
            "WHERE r.recipe.id = :recipeId")
    BigDecimal getRatingSummaryByRecipeId(@Param("recipeId") UUID recipeId);
}
