using Infraestrutura.Repository.External.Response;

namespace Infraestrutura.Repository.External;

public interface IExternalRepository
{
    public Task<BaseResponseExternal> SendWebHttp(string url);
    public Task<BaseResponseExternal> SendWebWithHeadersHttp(string url,string key,string value);
}