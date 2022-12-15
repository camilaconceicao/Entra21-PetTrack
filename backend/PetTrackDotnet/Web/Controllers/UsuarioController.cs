using Aplication.Interfaces;
using Aplication.Models.Request.Usuario;
using Aplication.Models.Response.Usuario;
using Infra.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : DefaultController
{
    protected readonly IUsuarioApp App;
    
    public UsuarioController(IUsuarioApp usuarioApp)
    {
        App = usuarioApp;
    }

    [HttpPost]
    [Route("Cadastrar")]
    public JsonResult Cadastrar(UsuarioRequest request)
    {
        try
        {
            var cadastro = App.Cadastrar(request);
            
            if(cadastro.Validators.IsValid())
                return ResponderSucesso("Cadastro realizado com sucesso!",cadastro.Autenticacao);
            
            return ResponderErro(cadastro.Validators.LErrors.FirstOrDefault());

        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("ConsultarTodos")]
    public JsonResult ConsultarTodos()
    {
        try
        {
            var objeto = new UsuarioResponse()
            {
                itens = App.GetAll()
            };
            
            return ResponderSucesso(objeto);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    [Route("ConsultarViaId/{id}")]
    public JsonResult ConsultarViaId(int id)
    {
        try
        {
            return ResponderSucesso(App.GetById(id));
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    
    [HttpPost]
    [Authorize]
    [Route("Editar")]
    public JsonResult Editar(Usuario usuario)
    {
        try
        {
            App.Editar(usuario);
            return ResponderSucesso("Usuário editado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    [Route("DeleteById")]
    public JsonResult DeleteById(int id)
    {
        try
        {
            App.DeleteById(id);
            return ResponderSucesso("Usuário deletado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}