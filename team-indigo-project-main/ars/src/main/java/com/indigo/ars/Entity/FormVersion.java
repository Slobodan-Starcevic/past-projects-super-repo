package com.indigo.ars.Entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Entity
@AllArgsConstructor
@NoArgsConstructor
@Builder
@Data
@Table(name = "version")
public class FormVersion {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Integer id;

    @Column(name = "version")
    private Integer version;

    @OneToOne
    @JoinColumn(name = "changer_id", referencedColumnName = "id")
    private Employee reporter;

    @OneToOne
    @JoinColumn(name = "form_id", referencedColumnName = "id")
    private Form form;

    @Column(name = "datetime")
    private LocalDateTime datetime;

    @Column(name = "data", length = 2000)
    private String data;

    @Column(name = "message")
    private String message;
}
