using Aplication.Models.Request.Care;
using Aplication.Models.Request.Ong;
using Aplication.Models.Request.Pet;
using Aplication.Models.Request.Usuario;
using Aplication.Models.Response.Endereco;
using Aplication.Models.Response.Login;
using Aplication.Models.Response.Pet;
using Aplication.Utils.HashCripytograph;
using AutoMapper;
using Domain.DTO.Correios;
using Infra.Data.Entity;

namespace Aplication.AutoMapper;

public class Mapping : Profile
{
    public Mapping()
    {
        #region Usuario
        CreateMap<UsuarioRequest, Usuario>()
                    .ForMember(dst => dst.Senha,
                        map => map.MapFrom(src => new HashCripytograph().Hash(src.Senha)));

        CreateMap<Usuario, LoginResponse>()
            .ForMember(dst => dst.Autenticado,
                map => map.MapFrom(src => true));

        #endregion

        #region Endereço
        CreateMap<EnderecoExternalReponse,EnderecoResponse>()
            .ForMember(dst => dst.Bairro,
                map => map.MapFrom(src => src.bairro))
            .ForMember(dst => dst.Cidade,
                map => map.MapFrom(src => src.localidade))
            .ForMember(dst => dst.Estado,
                map => map.MapFrom(src => src.uf))
            .ForMember(dst => dst.Rua,
                map => map.MapFrom(src => src.logradouro));

        #endregion

        #region Pet

        CreateMap<PetRequest, Pet>()
            .ForMember(dst => dst.DataCadastro,
                map => map.MapFrom(src => DateTime.Now));
       
        CreateMap<Pet, PetConsultaResponse>()
            .ForMember(dst => dst.DataCadastro,
                map => map.MapFrom(src => src.DataCadastro.ToShortDateString()))
            .ForMember(dst => dst.Tamanho,
                map => map.MapFrom(src => src.Tamanho.ToString()));

        #endregion

        #region Ong
        CreateMap<OngRequest, Ong>()
            .ForMember(dst => dst.DataCadastro,
                map => map.MapFrom(src => DateTime.Now));
        #endregion

        #region Care
        CreateMap<CareRequest, Care>()
            .ForMember(dst => dst.DataCadastro,
                map => map.MapFrom(src => DateTime.Now));
        #endregion
    }
}