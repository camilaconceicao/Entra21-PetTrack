using Aplication.Interfaces;
using Aplication.Models.Request.Base;
using Aplication.Models.Request.Pet;
using Aplication.Models.Response;
using Aplication.Models.Response.Pet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : DefaultController
{
    protected readonly IPetApp App;
    
    public PetController(IPetApp petApp)
    {
        App = petApp;
    }

    [HttpPost]
    [Authorize]
    [Route("Cadastrar")]
    public JsonResult Cadastrar(PetRequest request)
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
            var objeto = new PetListResponse()
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
    public JsonResult Editar(PetRequest request)
    {
        try
        {
            var cadastro = App.Editar(request);
            
            if(cadastro.IsValid())
                return ResponderSucesso("Pet editado com sucesso!");
            
            return ResponderErro(cadastro.LErrors.FirstOrDefault());
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    [Route("DeleteById/{id}")]
    public JsonResult DeleteById(int id)
    {
        try
        {
            App.DeleteById(id);
            return ResponderSucesso("Pet deletado com sucesso!");
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    [Route("ConsultarGridPet")]
    public JsonResult ConsultarGridPet(BaseGridRequest request)
    {
        try
        {
            var retorno = App.ConsultarGridPet(request);
            
            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpGet]
    [Route("ConsultarPetsPerdidos")]
    public JsonResult ConsultarPetsPerdidos()
    {
        try
        {
            var retorno = App.ConsultarPetsPerdidos();
            
            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpGet]
    [Route("ConsultarPetsAdocao")]
    public JsonResult ConsultarPetsAdocao()
    {
        try
        {
            var retorno = App.ConsultarPetsAdocao();
            
            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}