package br.com.pettrack.pettrack.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import br.com.pettrack.pettrack.models.PetCare;

@Repository
public interface PetCareRepository extends JpaRepository<PetCare, Long> {

}
