package br.com.pettrack.pettrack.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import br.com.pettrack.pettrack.models.Pet;
import br.com.pettrack.pettrack.services.PetService;

@RestController
public class PetController {
    @Autowired
    PetService petService;

    @GetMapping("/busca-pet/")
    public List<Pet> getAll() {
        return petService.getAll();
    }

    @GetMapping("/busca-pet/{nome}")
    public ResponseEntity<Optional<Pet>> getByName(@PathVariable String name) {
        return petService.getByName(name);
    }
}
