using Aplication.Interfaces;
using Aplication.Models.Request.Login;
using Aplication.Models.Request.Ong;
using Aplication.Models.Response;
using Aplication.Models.Response.Ong;
using Aplication.Utils.Obj;
using Aplication.Validators.Ong;
using AutoMapper;
using Domain.Interfaces;
using Infraestrutura.Entity;

namespace Aplication.Controllers;

public class OngApp : IOngApp
{
    protected readonly IOngService Service;
    protected readonly IMapper Mapper;
    protected readonly IOngValidator Validation;
    protected readonly IAuthApp Auth;
    
    public OngApp(IOngService service,IMapper mapper,IOngValidator validation, IAuthApp auth)
    {
        Service = service;
        Mapper = mapper;
        Validation = validation;
        Auth = auth;
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
            validation.Validators.LErrors.Add("Cadastro inválido,possui uma Ong como mesmo nome informado!");

        if(validation.Validators.IsValid())
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
            validation.Validators.LErrors.Add("Cadastro inválido,possui uma Ong como mesmo nome informado!");

        if(validation.Validators.IsValid())
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

