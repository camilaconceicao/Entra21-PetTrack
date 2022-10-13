package br.com.pettrack.pettrack.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import br.com.pettrack.pettrack.models.PetCare;
import br.com.pettrack.pettrack.services.PetCareService;

@RestController
public class PetCareController {
    @Autowired
    PetCareService petCareService;

    @GetMapping("/pet-care/")
    public List<PetCare> listAll() {
        return petCareService.getAll();
    }

    @GetMapping("/pet-care/{id}")
    public Optional<PetCare> descOneById(@PathVariable Long id) {
        return petCareService.getById(id);
    }
}
