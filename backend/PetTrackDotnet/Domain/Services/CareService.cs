using Domain.Interfaces;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Care;

namespace Domain.Services;

public class CareService : ICareService
{
    protected readonly ICareReadRepository ReadRepository;
    protected readonly ICareWriteRepository WriteRepository;

    public CareService(ICareReadRepository readRepository,ICareWriteRepository writeRepository)
    {
        ReadRepository = readRepository;
        WriteRepository = writeRepository;
    }

    public Care GetById(int id)
    {
        return ReadRepository.GetById(id);
    }
    
    public List<Care> GetAllList()
    {
        return ReadRepository.GetAll().ToList();
    }
    
    public IQueryable<Care> GetAllQuery()
    {
        return ReadRepository.GetAll();
    }

    public void Cadastrar(Care Care)
    {
        WriteRepository.Add(Care);
    }
    
    public Care CadastrarComRetorno(Care Care)
    {
        return WriteRepository.AddWithReturn(Care);
    }

    public void Editar(Care Care)
    {
        WriteRepository.Update(Care);
    }

    public void DeleteById(int id)
    {
        WriteRepository.DeleteById(id);
    }
}