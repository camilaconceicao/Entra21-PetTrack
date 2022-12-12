using System.Net;
using System.Text.Json;
using Domain.DTO.Correios;
using Domain.Interfaces;
using Infraestrutura.Repository.External;


namespace Domain.Services;

public class UtilService : IUtilsService
{
    protected readonly IExternalRepository External;

    private readonly IConfiguration _configuration;
    public UtilService(IExternalRepository external,IConfiguration config)
    {
        External = external;
        _configuration = config;
    }
    public async Task<EnderecoExternalReponse> ConsultarEnderecoCep(string cep)
    {
        EnderecoExternalReponse retorno;
        var url = _configuration.GetSection("ApiCorreios:Link");       
        var requisicao = await External.SendWebHttp(url.Value + cep +"/json");

        if (requisicao.StatusCode == HttpStatusCode.OK)
        {
            if (requisicao.ObjetoJson != null)
            { 
                retorno = JsonSerializer.Deserialize<EnderecoExternalReponse>(requisicao.ObjetoJson)
                        ?? new EnderecoExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };

                if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) || string.IsNullOrEmpty(retorno.uf) 
                    || string.IsNullOrEmpty(retorno.logradouro))
                {
                    retorno.StatusApi = false;
                }
                
                return retorno;
            }
            
        }
        
        retorno = JsonSerializer.Deserialize<EnderecoExternalReponse>(requisicao.ObjetoJson ?? "")
               ?? new EnderecoExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };
        
        if (string.IsNullOrEmpty(retorno.bairro) || string.IsNullOrEmpty(retorno.localidade) || string.IsNullOrEmpty(retorno.uf) 
            || string.IsNullOrEmpty(retorno.logradouro))
        {
            retorno.StatusApi = false;
        }

        return retorno;
    }
    
    public async Task<LatLongExternalReponse> ConsultarLatLongPorCep(string cep)
    {
        LatLongExternalReponse retorno;
        var url = _configuration.GetSection("CepAberto:Link");    
        var key = _configuration.GetSection("CepAberto:Key");  
        var value = _configuration.GetSection("CepAberto:Value");  

        var requisicao = await External.SendWebWithHeadersHttp(url.Value + cep,key.Value,value.Value);

        if (requisicao.StatusCode == HttpStatusCode.OK)
        {
            if (requisicao.ObjetoJson != null)
            { 
                retorno = JsonSerializer.Deserialize<LatLongExternalReponse>(requisicao.ObjetoJson)
                          ?? new LatLongExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };

                if (string.IsNullOrEmpty(retorno.latitude) || string.IsNullOrEmpty(retorno.longitude))
                    retorno.StatusApi = false;

                return retorno;
            }
            
        }
        
        retorno = JsonSerializer.Deserialize<LatLongExternalReponse>(requisicao.ObjetoJson ?? "")
                  ?? new LatLongExternalReponse() { StatusApi = false, StatusCode = requisicao.StatusCode };
        
        if (string.IsNullOrEmpty(retorno.latitude) || string.IsNullOrEmpty(retorno.longitude))
            retorno.StatusApi = false;

        return retorno;
    }
}