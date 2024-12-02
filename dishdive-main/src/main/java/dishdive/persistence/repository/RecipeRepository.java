package dishdive.persistence.repository;

import dishdive.business.service.RecipeService;
import dishdive.persistence.entity.ChefEntity;
import dishdive.persistence.entity.RecipeEntity;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Repository
public interface RecipeRepository extends CrudRepository<RecipeEntity, UUID>, JpaSpecificationExecutor<RecipeEntity> {

    Page<RecipeEntity> findAll(Specification<RecipeEntity> spec, Pageable pageable);

    List<RecipeEntity> findAll(Specification<RecipeEntity> spec);

    List<RecipeEntity> findAllByPoster(ChefEntity chef);

    Optional<RecipeEntity> findById(UUID id);
}
