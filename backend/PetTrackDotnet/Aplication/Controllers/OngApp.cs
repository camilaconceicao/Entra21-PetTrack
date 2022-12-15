using Aplication.Interfaces;
using Aplication.Models.Request.Ong;
using Aplication.Utils.Obj;
using Aplication.Validators.Ong;
using AutoMapper;
using Domain.Interfaces;
using Infra.Data.Entity;

namespace Aplication.Controllers;

public class OngApp : IOngApp
{
    protected readonly IOngService Service;
    protected readonly IMapper Mapper;
    protected readonly IOngValidator Validation;
    
    public OngApp(IOngService service,IMapper mapper,IOngValidator validation)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
    }

    public List<Ong> GetAll()
    {
        return Service.GetAllList();
    }

    public Ong GetById(int id)
    {
        return Service.GetById(id);
    }

    public ValidationResult Cadastrar(OngRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);

        var lOng = Service.GetAllQuery();

        if (lOng.Any(x => x.Nome == request.Nome))
            validation.LErrors.Add("Cadastro inválido,possui uma Ong como mesmo nome informado!");

        if(validation.IsValid())
        {
            var ong = Mapper.Map<OngRequest,Ong>(request);
            Service.Cadastrar(ong);
        }

        return validation;
    }
    
    public ValidationResult Editar(OngRequest request)
    {
        var validation = Validation.ValidaçãoCadastro(request);

        var lOng = Service.GetAllQuery();

        if (lOng.Any(x => x.Nome == request.Nome && request.IdOng != x.IdOng))
            validation.LErrors.Add("Cadastro inválido,possui uma Ong como mesmo nome informado!");

        if(validation.IsValid())
        {
            var ong = Mapper.Map<OngRequest,Ong>(request);
            Service.Editar(ong);
        }

        return validation;
    }

    public void DeleteById(int id)
    {
        Service.DeleteById(id);
    }
}

