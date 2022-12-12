namespace Aplication.Models.Response.Pet;

public class PetConsultaResponse
{ 
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string FotoBase64 { get; set; } = null!;
    public int UsuarioCadastroId { get; set; }
    public string DataCadastro { get; set; }
    public string Tamanho { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
}



