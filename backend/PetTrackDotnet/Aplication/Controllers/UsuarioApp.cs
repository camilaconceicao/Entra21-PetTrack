﻿using Aplication.Interfaces;
using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Validators.Usuario;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;
public class UsuarioApp : IUsuarioApp
{
    protected readonly IUsuarioService Service;
    protected readonly IMapper Mapper;
    protected readonly IUsuarioValidator Validation;
    protected readonly IUtilsService UtilsService;

    public UsuarioApp(IUsuarioService service,IMapper mapper,IUsuarioValidator validation, IUtilsService utilsService)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
        UtilsService = utilsService;
    }

    public List<Usuario> GetAll()
    {
        return Service.GetAllList();
    }

    public Usuario? GetByCpf(string cpf)
    {
        return Service.GetByCpf(cpf);
    }

    public Usuario GetById(int id)
    {
        return Service.GetById(id);
    }

    public ValidationResult Cadastrar(UsuarioRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);
        var lUsuario = Service.GetAllList();

        if (lUsuario.Any(x => x.Email == request.Email && x.IdUsuario != request.IdUsuario))
            validation.LErrors.Add("Email já vinculado a outro usuário");

        if(validation.IsValid())
        {
            var usuario = Mapper.Map<UsuarioRequest,Usuario>(request);
            Service.Cadastrar(usuario);
        }

        return validation;
    }

    public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request)
    {
        var validation = Validation.ValidaçãoCadastroInicial(request);
        var lUsuario = Service.GetAllList();

        if (lUsuario.Any(x => x.Email == request.Email))
            validation.LErrors.Add("Email já vinculado a outro usuário");
        
        if(validation.IsValid())
        {
            var usuario = Mapper.Map<UsuarioRegistroInicialRequest,Usuario>(request);
            Service.Cadastrar(usuario);
        }

        return validation;
    }

    public void CadastrarListaUsuario(List<Usuario> lUsuario)
    {
        Service.CadastrarListaUsuario(lUsuario);
    }
    
    public void Editar(Usuario usuario)
    {
        Service.Editar(usuario);
    }
    
    public void EditarListaUsuario(List<Usuario> lUsuario)
    {
        Service.EditarListaUsuario(lUsuario);
    }
    
    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
}

