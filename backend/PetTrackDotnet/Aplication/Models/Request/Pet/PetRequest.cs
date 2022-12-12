using Infraestrutura.Enum;

namespace Aplication.Models.Request.Pet;

public class PetRequest
{
    public int? IdPet { get; set; }
    public string? Nome { get; set; } = null!;
    public string? Descricao { get; set; } = null!;
    public string? FotoBase64 { get; set; } = null!;
    public string? Raca { get; set; } = null!;
    public string? Cep { get; set; } 
    public string? Cidade { get; set; } 
    public string? Rua { get; set; } 
    public string? Bairro { get; set; } 
    public int? UsuarioCadastroId { get; set; }
    public ETamanho Tamanho { get; set; }
    public ETipoCadastro TipoCadastro { get; set; }
}