package dishdive.persistence.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Entity
@Table(name = "rating")
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class RatingEntity {
    @Id
    @Column(name = "id")
    private UUID id;

    @ManyToOne
    @JoinColumn(name = "rater", referencedColumnName = "id")
    private ChefEntity rater;

    @ManyToOne
    @JoinColumn(name = "recipe", referencedColumnName = "id")
    private RecipeEntity recipe;

    @Column(name = "score", nullable = false)
    private int score;

    @Column(name = "comment", nullable = true)
    private String comment;
}
