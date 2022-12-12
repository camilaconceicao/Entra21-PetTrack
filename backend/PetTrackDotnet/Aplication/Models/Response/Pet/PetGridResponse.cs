namespace Aplication.Models.Response.Pet;

public class PetGridResponse
{ 
    public int IdPet { get; set; }
    public string Nome { get; set; } = null!;
    public string FotoBase64 { get; set; } = null!;
    public string? Local { get; set; }
    public string TipoCadastro { get; set; }
}