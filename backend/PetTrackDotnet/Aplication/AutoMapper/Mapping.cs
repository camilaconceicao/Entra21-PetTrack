using Aplication.Models.Request.Usuario;
using Aplication.Models.Response;
using Aplication.Utils.HashCripytograph;
using AutoMapper;
using Domain.DTO.Correios;
using Infraestrutura.Entity;

namespace Aplication.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        #region Usuario
        CreateMap<UsuarioRequest, Usuario>()
            .ForMember(dst => dst.Senha,
                map => map.MapFrom(src => new HashCripytograph().Hash(src.Senha)));
        
        CreateMap<UsuarioRegistroInicialRequest, Usuario>()
            .ForMember(dst => dst.Senha,
                map => map.MapFrom(src => new HashCripytograph().Hash(src.Senha)));
        #endregion

        CreateMap<EnderecoExternalReponse,EnderecoResponse>()
            .ForMember(dst => dst.Bairro,
                map => map.MapFrom(src => src.bairro))
            .ForMember(dst => dst.Cidade,
                map => map.MapFrom(src => src.localidade))
            .ForMember(dst => dst.Estado,
                map => map.MapFrom(src => src.uf))
            .ForMember(dst => dst.Rua,
                map => map.MapFrom(src => src.logradouro));
    }
}