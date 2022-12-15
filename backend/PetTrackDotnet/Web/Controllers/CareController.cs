using Aplication.Interfaces;
using Aplication.Models.Request.Care;
using Aplication.Models.Response.Care;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CareController : DefaultController
{
    protected readonly ICareApp App;
    
    public CareController(ICareApp careApp)
    {
        App = careApp;
    }

    [HttpPost]
    [Authorize]
    [Route("Cadastrar")]
    public JsonResult Cadastrar(CareRequest request)
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
            var objeto = new CareResponse()
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
    public JsonResult Editar(CareRequest request)
    {
        try
        {
            var cadastro = App.Editar(request);
            
            if(cadastro.IsValid())
                return ResponderSucesso("Pet Care editada com sucesso!");
    
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
            return ResponderSucesso("Pet Care deletada com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}