package dishdive.persistence.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.List;
import java.util.UUID;

@Entity
@Table(name = "recipe")
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class RecipeEntity {
    @Id
    @Column(name = "id")
    private UUID id;

    @ManyToOne
    @JoinColumn(name = "poster")
    private ChefEntity poster;

    @Column(name = "title")
    private String title;

    @Column(name = "description")
    private String description;

    @Column(name = "creation_time")
    private LocalDateTime creationTime;

    @Column(name = "servings")
    private Integer servings;

    @Column(name = "prep_time")
    private Integer prepTime;

    @Column(name = "cook_time")
    private Integer cookTime;

    @Enumerated(EnumType.STRING)
    @Column(name = "recipe_tag")
    private TagEnum recipeTag;

    @Column(name = "ingredients")
    private String ingredients;

    @Column(name = "rating")
    private BigDecimal rating;
}
