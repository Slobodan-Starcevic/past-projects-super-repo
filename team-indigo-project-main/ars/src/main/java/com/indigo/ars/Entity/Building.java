package com.indigo.ars.Entity;

import jakarta.persistence.*;
import lombok.*;

import java.util.UUID;


@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Table(name = "building")
public class Building {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Integer id;
    @Getter
    private String address;
    @Getter
    private String city;

}
