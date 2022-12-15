namespace Aplication.Models.Request.Ong;

public class OngRequest
{
    public int? IdOng { get; set; }
    public string? Nome { get; set; } = null!;
    public string? RazaoSocial { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Pix { get; set; } = null!;
    public string? Descricao { get; set; } = null!;
    public string? FotoBase64 { get; set; } = null!;
}