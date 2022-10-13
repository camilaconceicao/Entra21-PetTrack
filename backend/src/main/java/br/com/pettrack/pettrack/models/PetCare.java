package br.com.pettrack.pettrack.models;

import javax.persistence.Entity;
import javax.persistence.Table;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "petcare")
@Data @AllArgsConstructor @NoArgsConstructor
public class PetCare {
    private Long id;
    private String nome;
    private String desc;
}
