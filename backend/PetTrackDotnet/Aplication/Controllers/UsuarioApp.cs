using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Request.Usuario;
using Aplication.Models.Response.Usuario;
using Aplication.Validators.Usuario;
using AutoMapper;
using Domain.Interfaces;
using Infra.Data.Entity;

namespace Aplication.Controllers;
public class UsuarioApp : IUsuarioApp
{
    protected readonly IUsuarioService Service;
    protected readonly IMapper Mapper;
    protected readonly IUsuarioValidator Validation;
    protected readonly IAuthApp Auth;
    
    public UsuarioApp(IUsuarioService service,IMapper mapper,IUsuarioValidator validation, IAuthApp auth)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
        Auth = auth;
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

    public UsuarioCadastroResponse Cadastrar(UsuarioRequest request)
    {
        var retorno = new UsuarioCadastroResponse()
        {
            Validators = Validation.ValidaçãoCadastro(request)
        };

        var requestLogin = new LoginRequest()
        {
            EmailLogin = request.Email ?? string.Empty,
            SenhaLogin = request.Senha
        };
        
        var lUsuario = Service.GetAllQuery();

        if (lUsuario.Any(x => x.Email == request.Email))
            retorno.Validators.LErrors.Add("Email já vinculado a outro usuário");

        if(retorno.Validators.IsValid())
        {
            var usuario = Mapper.Map<UsuarioRequest,Usuario>(request);
            Service.Cadastrar(usuario);
            
            retorno.Autenticacao = Auth.Login(requestLogin);
        }

        return retorno;
    }
    
    public void Editar(Usuario usuario)
    {
        Service.Editar(usuario);
    }

    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
}

