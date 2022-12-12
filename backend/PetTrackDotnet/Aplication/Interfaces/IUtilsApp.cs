using Aplication.Models.Response;
using Aplication.Models.Response.Endereco;

namespace Aplication.Interfaces;

public interface IUtilsApp
{
    public EnderecoResponse ConsultarEnderecoCep(string cep);
    public LatLongResponse ConsultarLatLongPorCep(string cep);
}