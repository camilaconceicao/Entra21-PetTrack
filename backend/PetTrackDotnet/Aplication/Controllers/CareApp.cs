using Aplication.Interfaces;
using Aplication.Models.Request.Care;
using Aplication.Utils.Obj;
using Aplication.Validators.Care;
using AutoMapper;
using Domain.Interfaces;
using Infra.Data.Entity;

namespace Aplication.Controllers;

public class CareApp : ICareApp
{
    protected readonly ICareService Service;
    protected readonly IMapper Mapper;
    protected readonly ICareValidator Validation;
    
    public CareApp(ICareService service,IMapper mapper,ICareValidator validation)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
    }

    public List<Care> GetAll()
    {
        return Service.GetAllList();
    }

    public Care GetById(int id)
    {
        return Service.GetById(id);
    }

    public ValidationResult Cadastrar(CareRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);

        var lCare = Service.GetAllQuery();

        if (lCare.Any(x => x.Nome == request.Nome))
            validation.LErrors.Add("Cadastro inválido,possui uma Care como mesmo nome informado!");

        if(validation.IsValid())
        {
            var care = Mapper.Map<CareRequest,Care>(request);
            Service.Cadastrar(care);
        }

        return validation;
    }
    
    public ValidationResult Editar(CareRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);

        var lCare = Service.GetAllQuery();

        if (lCare.Any(x => x.Nome == request.Nome && request.IdCare != x.IdCare))
            validation.LErrors.Add("Cadastro inválido,possui uma Care como mesmo nome informado!");

        if(validation.IsValid())
        {
            var care = Mapper.Map<CareRequest,Care>(request);
            Service.Editar(care);
        }

        return validation;
    }

    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
}

