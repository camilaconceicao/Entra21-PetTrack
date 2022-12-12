namespace Aplication.Models.Response.Login;

public class LoginResponse
{
    public bool Autenticado { get; set; }
    public string Nome { get; set; }
    public object SessionKey { get; set; }
    public int IdUsuario { get; set; }
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
}