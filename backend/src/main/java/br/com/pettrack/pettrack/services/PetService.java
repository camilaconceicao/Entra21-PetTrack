package br.com.pettrack.pettrack.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import br.com.pettrack.pettrack.models.Pet;
import br.com.pettrack.pettrack.repositories.PetRepository;

@Service
public class PetService {
    @Autowired
    PetRepository petRepository;
    
    public List<Pet> getAll() {
        return petRepository.findAll();
    }

    public ResponseEntity<Optional<Pet>> getByName(String name) {
        return ResponseEntity.ok(petRepository.findByName(name));
    }

    public void save(Pet pet) {
        petRepository.save(pet);
    }
}
