using System.Linq.Dynamic.Core;
using Aplication.Interfaces;
using Aplication.Models.Request.Base;
using Aplication.Models.Request.Pet;
using Aplication.Models.Response.Base;
using Aplication.Models.Response.Pet;
using Aplication.Utils.Filter;
using Aplication.Utils.Obj;
using Aplication.Validators.Pet;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Infra.Data.Entity;
using Infraestrutura.Enum;

namespace Aplication.Controllers;

public class PetApp : IPetApp
{
    protected readonly IPetService Service;
    protected readonly IMapper Mapper;
    protected readonly IPetValidator Validation;
    protected readonly IUtilsService Utils;

    public PetApp(IPetService service,IMapper mapper,IPetValidator validation, IUtilsService utils)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
        Utils = utils;
    }

    public List<Pet> GetAll()
    {
        return Service.GetAllList();
    }

    public PetResponse GetById(int id)
    {
        var retorno = Service.GetById(id);
        return new PetResponse()
        {
            Endereco = new Endereco()
            {
                Bairro = retorno.Bairro,
                Cep = retorno.Cep,
                Cidade = retorno.Cidade,
                Rua = retorno.Rua
            },
            DadosCadastrais = new Dados()
            {
                Descricao = retorno.Descricao,
                TipoPet = retorno.TipoCadastro.GetHashCode().ToString(),
                Termo = true
            },
            Informacoes = new Informacoes()
            {
                Foto = retorno.FotoBase64,
                IdPet = retorno.IdPet,
                Nome = retorno.Nome,
                Raca = retorno.Raca,
                Porte = retorno.Tamanho.GetHashCode().ToString()
            }
        };
    }

    public ValidationResult Cadastrar(PetRequest request)
    {
        var retorno = Validation.ValidaçãoCadastro(request);

        if(retorno.IsValid())
        {
            var pet = Mapper.Map<PetRequest,Pet>(request);
            var consultaLatLong =  Utils.ConsultarLatLongPorCep(request.Cep ?? "");

            pet.Latitude = consultaLatLong.Result.latitude;
            pet.Longitude = consultaLatLong.Result.longitude;
                
            Service.Cadastrar(pet);
        }

        return retorno;
    }
    
    public ValidationResult Editar(PetRequest request)
    {
        var retorno = Validation.ValidaçãoCadastro(request);

        if(retorno.IsValid())
        {
            var pet = Mapper.Map<PetRequest,Pet>(request);
            var consultaLatLong =  Utils.ConsultarLatLongPorCep(request.Cep ?? "");

            pet.Latitude = consultaLatLong.Result.latitude;
            pet.Longitude = consultaLatLong.Result.longitude;
                
            Service.Editar(pet);
        }

        return retorno;
    }

    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
    
    public BaseGridResponse ConsultarGridPet(BaseGridRequest request)
    {
        var itens = Service.GetAllQuery();
        
        itens = string.IsNullOrEmpty(request.OrderFilters?.Campo)
            ? itens.OrderByDescending(x => x.IdPet)
            : itens.OrderBy($"{request.OrderFilters.Campo} {request.OrderFilters.Operador.ToString()}");

        itens = itens.AplicarFiltrosDinamicos(request.QueryFilters);
        
        return new BaseGridResponse()
        {
            Itens = itens.Skip(request.Page * request.Take).Take(request.Take)
                .Select(x => new PetGridResponse()
                {
                    IdPet = x.IdPet,
                    Nome = x.Nome,
                    FotoBase64 = x.FotoBase64,
                    Local = x.Cidade + " / " + x.Bairro + " / " + x.Rua,
                    TipoCadastro = x.TipoCadastro.ToString()
                }).ToList(),
            
            TotalItens = itens.Count()
        };
    }

    public List<PetConsultaResponse> ConsultarPetsAdocao()
    {
        var itens = Service.GetAllQuery();

        return itens.Where(x => x.TipoCadastro == ETipoCadastro.Doacao)
            .ProjectTo<PetConsultaResponse>(Mapper.ConfigurationProvider).ToList();
    }

    public List<PetConsultaResponse> ConsultarPetsPerdidos()
    {
        var itens = Service.GetAllQuery();
        
        return itens.Where(x => x.TipoCadastro == ETipoCadastro.Perdido)
            .ProjectTo<PetConsultaResponse>(Mapper.ConfigurationProvider).ToList();
    }
}

