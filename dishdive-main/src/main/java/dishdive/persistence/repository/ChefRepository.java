package dishdive.persistence.repository;

import dishdive.persistence.entity.ChefEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Repository
public interface ChefRepository extends JpaRepository<ChefEntity, UUID> {
    boolean existsByUsernameOrEmail(String username, String email);

    Optional<ChefEntity> findByUsernameOrEmail(String username, String email);

    Optional<ChefEntity> findById(UUID id);

    Optional<ChefEntity> findByUsername(String username);

    List<ChefEntity> findAll();
}
