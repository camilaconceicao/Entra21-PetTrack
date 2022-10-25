package br.com.pettrack.pettrack.repositories;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import br.com.pettrack.pettrack.models.Ong;

@Repository
public interface OngRepository extends JpaRepository<Ong, Long> {
    Optional<Ong> findByName(String name);

}
