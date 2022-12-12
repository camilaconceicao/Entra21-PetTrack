﻿using Aplication.Interfaces;
using Aplication.Models.Response;
using Aplication.Models.Response.Endereco;
using Aplication.Validators.Utils;
using AutoMapper;
using Domain.DTO.Correios;
using Domain.Interfaces;

namespace Aplication.Controllers;

public class UtilsApp : IUtilsApp
{
    protected readonly IUtilsService UtilsService;
    protected readonly IUtilsValidator UtilsValidation;
    protected readonly IMapper Mapper;

    public UtilsApp(IUtilsService utilsService,IUtilsValidator utilsValidation,IMapper mapper)
    {
        UtilsService = utilsService;
        UtilsValidation = utilsValidation;
        Mapper = mapper;
    }

    public EnderecoResponse ConsultarEnderecoCep(string cep)
    {
        var validation = UtilsValidation.ValidarCep(cep);

        if (!validation.IsValid())
            return Mapper.Map<EnderecoResponse>(validation);

        var retorno = UtilsService.ConsultarEnderecoCep(cep).Result;
        
        return Mapper.Map<EnderecoExternalReponse,EnderecoResponse>(retorno);
    }
    
    public LatLongResponse ConsultarLatLongPorCep(string cep)
    {
        var validation = UtilsValidation.ValidarCep(cep);

        if (!validation.IsValid())
            return Mapper.Map<LatLongResponse>(validation);

        var retorno = UtilsService.ConsultarLatLongPorCep(cep).Result;
        
        return Mapper.Map<LatLongExternalReponse,LatLongResponse>(retorno);
    }
}