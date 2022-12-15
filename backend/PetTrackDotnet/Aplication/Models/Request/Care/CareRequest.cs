namespace Aplication.Models.Request.Care;

public class CareRequest
{
    public int? IdCare { get; set; }
    public string? Nome { get; set; } = null!;
    public string? Descricao { get; set; } = null!;
    public string? FotoBase64 { get; set; } = null!;
}