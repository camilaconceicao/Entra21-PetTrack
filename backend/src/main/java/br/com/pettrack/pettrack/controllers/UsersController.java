package br.com.pettrack.pettrack.controllers;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
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
@CrossOrigin("*")
public class UsersController {
    @Autowired
    UsersService usersService;

    @PostMapping("/cadastro/")
    public Long cadastrar(@RequestBody Users users) throws NoSuchAlgorithmException, UnsupportedEncodingException {
        Long id = 0L;

        if (users.getId() == 0) {
            Users a = new Users();
            a.setEmail(users.getEmail());
            a.setSenha(hashSenha(users.getSenha()));
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

    @PostMapping("/auth")
    public boolean logar(@RequestBody Users authModel) throws NoSuchAlgorithmException, UnsupportedEncodingException {
        Users user = usersService.findEmailAndPassword(authModel.getEmail(), hashSenha(authModel.getSenha()));
        return user == null ? false : true;
    }

    private String hashSenha(String senha)
            throws NoSuchAlgorithmException, UnsupportedEncodingException {
        MessageDigest algorithm = MessageDigest.getInstance("SHA-256");
        byte messageDigest[] = algorithm.digest(senha.getBytes("UTF-8"));

        StringBuilder hexString = new StringBuilder();
        for (byte b : messageDigest) {
            hexString.append(String.format("%02X", 0xFF & b));
        }
        String senhahex = hexString.toString().toLowerCase();
        return senhahex;
    }
}
