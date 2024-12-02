package dishdive.persistence.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Entity
@Table(name = "review")
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ReviewEntity {
    @Id
    @Column(name = "id")
    private UUID id;

    @ManyToOne
    @JoinColumn(name = "reviewer", referencedColumnName = "id")
    private ChefEntity reviewer;

    @ManyToOne
    @JoinColumn(name = "rating", referencedColumnName = "id")
    private RatingEntity rating;

    @Column(name = "comment", nullable = false)
    private String comment;

    @Column(name = "creation_time", nullable = false)
    private java.sql.Timestamp creationTime;
}
