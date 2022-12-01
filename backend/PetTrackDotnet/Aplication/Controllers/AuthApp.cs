﻿using Aplication.Authentication;
using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Response;
using Aplication.Utils.HashCripytograph;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;

public class AuthApp : IAuthApp
{
    protected readonly IUsuarioService UsuarioService;
    protected readonly IHashCriptograph Crypto;
    protected readonly IJwtTokenAuthentication Jwt;
    protected readonly IMapper Mapper;

    public AuthApp(IUsuarioService usuarioService,IHashCriptograph crypto,IJwtTokenAuthentication jwt, IMapper mapper)
    {
        UsuarioService = usuarioService;
        
        Crypto = crypto;
        Jwt = jwt;
        Mapper = mapper;
    }

    public LoginResponse Login(LoginRequest request)
    {
        var retorno = new LoginResponse();

        var usuario = UsuarioService.GetAllQuery()
            .FirstOrDefault(x => x.Email == request.EmailLogin && x.Senha ==
                Crypto.Hash(request.SenhaLogin));

        if (usuario == null)
            retorno.Autenticado = false;
        else
        { 
            retorno = Mapper.Map<Usuario,LoginResponse>(usuario);
            retorno.SessionKey = Jwt.GerarToken(usuario.Cpf);
        }

        return retorno;
    }
}