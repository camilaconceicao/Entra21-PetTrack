using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilsController : DefaultController
{
    protected readonly IUtilsApp UtilsApp;

    public UtilsController(IUtilsApp utilApp)
    {
        UtilsApp = utilApp;
    }

    [HttpGet]
    [Route("ConsultarEnderecoCep/{cep}")]
    public JsonResult ConsultarEnderecoCep(string cep)
    {
        try
        {
            var retorno = UtilsApp.ConsultarEnderecoCep(cep);

            if (!retorno.IsValid())
                return ResponderErro("Cep inválido!");

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpGet]
    [Route("ConsultarLatLongPorCep/{cep}")]
    public JsonResult ConsultarLatLongPorCep(string cep)
    {
        try
        {
            var retorno = UtilsApp.ConsultarLatLongPorCep(cep);

            if (!retorno.IsValid())
                return ResponderErro("Cep inválido!");

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}