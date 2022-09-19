package br.com.pettrack.pettrack.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import br.com.pettrack.pettrack.models.Users;

@Repository
public interface UsersRepository extends JpaRepository<Users, Long> {
    
}
