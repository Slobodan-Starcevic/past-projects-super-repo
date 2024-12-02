package com.indigo.ars.Entity;

import com.indigo.ars.Entity.converters.StringListConverter;
import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.List;

@Entity
@AllArgsConstructor
@NoArgsConstructor
@Builder
@Data
@Table(name = "form")
public class Form {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Integer id;

    @OneToOne
    @JoinColumn(name = "reporter_id", referencedColumnName = "id")
    private Employee reporter;

    @OneToOne
    @JoinColumn(name = "building_id", referencedColumnName = "id")
    private Building incidentLocation;;

    @Convert(converter = StringListConverter.class)
    @Column(name = "type", columnDefinition = "character varying[]")
    private List<String> type;

    @Column(name = "datetime")
    private LocalDateTime datetime;

    @Column(name = "data", length = 2000)
    private String data;

    @Column(name = "status")
    private String status;

    @Column(name = "severity")
    private String severity;
}
