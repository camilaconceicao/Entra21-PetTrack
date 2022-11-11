using Domain.DTO.Correios;

namespace Domain.Interfaces;

public interface IUtilsService
{
    public Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep);
}