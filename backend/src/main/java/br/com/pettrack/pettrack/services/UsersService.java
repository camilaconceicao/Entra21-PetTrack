package br.com.pettrack.pettrack.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import br.com.pettrack.pettrack.models.Users;
import br.com.pettrack.pettrack.repositories.UsersRepository;

@Service
public class UsersService {
    @Autowired
    UsersRepository usersRespository;

    public List<Users> getAll() {
        return usersRespository.findAll();
    }
    
    public void save(Users users) {
        usersRespository.save(users);
    }
}