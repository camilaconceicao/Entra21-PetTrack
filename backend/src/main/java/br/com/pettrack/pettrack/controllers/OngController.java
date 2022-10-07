package br.com.pettrack.pettrack.controllers;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import br.com.pettrack.pettrack.models.Ong;
import br.com.pettrack.pettrack.services.OngService;

@RestController
public class OngController {
    @Autowired
    OngService ongService;

    @GetMapping("/comunidade/")
    public List<Ong> getAll() {
        return ongService.getAll();
    }

    @GetMapping("/comunidade/{name}")
    public ResponseEntity<Optional<Ong>> getOne(@PathVariable String name) {
        return ongService.getByName(name);
    }
}
