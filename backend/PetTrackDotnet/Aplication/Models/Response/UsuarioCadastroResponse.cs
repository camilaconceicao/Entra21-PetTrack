using Aplication.Utils.Obj;

namespace Aplication.Models.Response;

public class UsuarioCadastroResponse 
{
    public LoginResponse Autenticacao { get; set; } = null!;
    public ValidationResult Validators { get; set; } = null!;
}