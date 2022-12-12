using Aplication.Utils.Obj;

namespace Aplication.Models.Response.Endereco;

public class LatLongResponse : ValidationResult
{ 
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
}