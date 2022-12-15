using Aplication.Interfaces;
using Aplication.Models.Request.Ong;
using Aplication.Models.Response.Ong;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class OngController : DefaultController
{
    protected readonly IOngApp App;
    
    public OngController(IOngApp ongApp)
    {
        App = ongApp;
    }

    [HttpPost]
    [Authorize]
    [Route("Cadastrar")]
    public JsonResult Cadastrar(OngRequest request)
    {
        try
        {
            var cadastro = App.Cadastrar(request);
            
            if(cadastro.IsValid())
                return ResponderSucesso("Cadastro realizado com sucesso!");
            
            return ResponderErro(cadastro.LErrors.FirstOrDefault());

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
            var objeto = new OngResponse()
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
    public JsonResult Editar(OngRequest request)
    {
        try
        {
            var cadastro = App.Editar(request);
            
            if(cadastro.IsValid())
                return ResponderSucesso("Ong editada com sucesso!");
    
            return ResponderErro(cadastro.LErrors.FirstOrDefault());

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
            return ResponderSucesso("Ong deletada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}