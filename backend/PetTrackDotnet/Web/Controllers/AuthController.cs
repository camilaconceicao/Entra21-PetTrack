using Aplication.Authentication;
using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Request.Token;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : DefaultController
{
    protected readonly IAuthApp AuthApp;
    protected readonly IJwtTokenAuthentication Token;
    protected readonly IUsuarioApp UsuarioApp;

    
    public AuthController(IAuthApp authApp,IJwtTokenAuthentication token,IUsuarioApp usuarioApp)
    {
        AuthApp = authApp;
        Token = token;
        UsuarioApp = usuarioApp;
    }

    [HttpPost]
    [Route("Login")]
    public JsonResult Login(LoginRequest request)
    {
        try
        {
            var retorno = AuthApp.Login(request);

            if (!retorno.Autenticado)
                return ResponderErro("Usuário ou senha inválido!");

            return ResponderSucesso("Seja bem vindo de volta " + retorno.Nome + "!",retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
    
    [HttpPost]
    [Route("GerarToken")]
    public JsonResult GerarToken(TokenRequest request)
    {
        try
        {
            var usuario = UsuarioApp.GetByCpf(request.Cpf);
            
            if(usuario == null)
                return ResponderErro("Não foi encontrado usuário com este CPF!");

            var retorno = Token.GerarToken(request.Cpf);

            return ResponderSucesso(retorno);
        }
        catch (Exception e)
        {
            return ResponderErro(e.Message);
        }
    }
}