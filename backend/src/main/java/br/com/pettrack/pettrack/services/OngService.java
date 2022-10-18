package br.com.pettrack.pettrack.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import br.com.pettrack.pettrack.models.Ong;
import br.com.pettrack.pettrack.repositories.OngRepository;

@Service
public class OngService {
    @Autowired
    OngRepository ongRepository;

    public List<Ong> getAll() {
        return ongRepository.findAll();
    }

    public ResponseEntity<Optional<Ong>> getByName(String name) {
        return ResponseEntity.ok(ongRepository.findByName(name));
    }

    public void save(Ong ong) {
        ongRepository.save(ong);
    }
}