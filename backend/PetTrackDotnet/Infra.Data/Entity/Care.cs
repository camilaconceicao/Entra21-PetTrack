namespace Infra.Data.Entity;

public class Care
{
    public int? IdCare { get; set; }
    public string? Nome { get; set; }
    public string? FotoBase64 { get; set; }
    public string? Descricao { get; set; }
    public DateTime? DataCadastro { get; set; }
}