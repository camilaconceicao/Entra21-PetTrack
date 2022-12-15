namespace Infra.Data.Entity;

public class Ong
{
    public int? IdOng { get; set; }
    public string? Nome { get; set; }
    public string? FotoBase64 { get; set; } = null!;
    public string? RazaoSocial { get; set; }
    public string? Email { get; set; }
    public string? Pix { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataCadastro { get; set; }
}