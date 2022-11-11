using Aplication.Models.Response;

namespace Aplication.Interfaces;

public interface IUtilsApp
{
    public EnderecoResponse ConsultarEnderecoCep(string cep);
}