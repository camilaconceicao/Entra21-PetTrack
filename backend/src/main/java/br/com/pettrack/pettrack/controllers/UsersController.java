package br.com.pettrack.pettrack.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import br.com.pettrack.pettrack.models.Users;
import br.com.pettrack.pettrack.services.UsersService;

@RestController
@CrossOrigin(origins = "http://localhost:4200")
public class UsersController {
    @Autowired
    UsersService usersService;

    @PostMapping("/cadastro/")
    public Long cadastrar(@RequestBody Users users) {
        Long id = 0L;

        if (users.getId() == 0) {
            Users a = new Users();
            a.setEmail(users.getEmail());
            a.setSenha(users.getSenha());
            this.usersService.save(a);

            id = a.getId();
        } else {
            this.usersService.save(users);

            id = users.getId();
        }

        return id;
    }

    @GetMapping("/users/")
    public List<Users> listAllUsers() {
        return this.usersService.getAll();
    }
}
