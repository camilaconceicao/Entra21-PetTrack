package br.com.pettrack.pettrack.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import br.com.pettrack.pettrack.models.PetCare;
import br.com.pettrack.pettrack.repositories.PetCareRepository;

@Service
public class PetCareService {
    @Autowired
    PetCareRepository petCareRepository;

    public List<PetCare> getAll() {
        return petCareRepository.findAll();
    }

    public Optional<PetCare> getById(Long id) {
        return petCareRepository.findById(id);
    }
}
