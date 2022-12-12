namespace Aplication.Models.Response.Pet;

public class PetResponse
{ 
    public Dados DadosCadastrais { get; set; } = null!;
    public Informacoes Informacoes { get; set; } = null!;
    public Endereco Endereco { get; set; } = null!;
}

public class Informacoes
{
    public int IdPet { get; set; }
    public string Nome { get; set; } = null!;
    public string Foto { get; set; } = null!;
    public string Raca { get; set; } = null!;
    public string Porte { get; set; }
}

public class Endereco 
{
    public string? Cep { get; set; } 
    public string? Cidade { get; set; } 
    public string? Rua { get; set; } 
    public string? Bairro { get; set; }
}

public class Dados
{
    public bool Termo { get; set; }
    public string Descricao { get; set; } = null!;
    public string TipoPet { get; set; }
}

