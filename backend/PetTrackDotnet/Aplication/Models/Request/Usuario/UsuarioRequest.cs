namespace Aplication.Models.Request.Usuario;

public class UsuarioRequest
{
    public int? IdUsuario { get; set; }
    public string? Nome { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Senha { get; set; } = null!;
    public string? Cep { get; set; } = null!;
    public string? Cidade { get; set; } = null!;
    public string? Rua { get; set; } = null!;
    public string? Bairro { get; set; } = null!;
    public int? Numero { get; set; }
    public string? Cpf { get; set; } = null!;
    public string? Telefone { get; set; } = null!;
    public DateTime? DataNascimento { get; set; }
}