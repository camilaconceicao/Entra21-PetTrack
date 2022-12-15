using Infraestrutura.Enum;

namespace Infra.Data.Entity;

public class Pet
{
    public int IdPet { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string FotoBase64 { get; set; } = null!;
    public string Raca { get; set; } = null!;
    public string? Cep { get; set; } 
    public string? Cidade { get; set; } 
    public string? Rua { get; set; } 
    public string? Bairro { get; set; } 
    public int UsuarioCadastroId { get; set; }
    public DateTime DataCadastro { get; set; }
    public ETamanho Tamanho { get; set; }
    public ETipoCadastro TipoCadastro { get; set; }
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;

    #region Relacionamento
    public virtual Usuario Usuario { get; set; } = null!;
    #endregion
}