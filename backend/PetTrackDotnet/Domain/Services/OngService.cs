using Domain.Interfaces;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Ong;

namespace Domain.Services;

public class OngService : IOngService
{
    protected readonly IOngReadRepository ReadRepository;
    protected readonly IOngWriteRepository WriteRepository;

    public OngService(IOngReadRepository readRepository,IOngWriteRepository writeRepository)
    {
        ReadRepository = readRepository;
        WriteRepository = writeRepository;
    }

    public Ong GetById(int id)
    {
        return ReadRepository.GetById(id);
    }
    
    public List<Ong> GetAllList()
    {
        return ReadRepository.GetAll().ToList();
    }
    
    public IQueryable<Ong> GetAllQuery()
    {
        return ReadRepository.GetAll();
    }

    public void Cadastrar(Ong Ong)
    {
        WriteRepository.Add(Ong);
    }
    
    public Ong CadastrarComRetorno(Ong Ong)
    {
        return WriteRepository.AddWithReturn(Ong);
    }

    public void Editar(Ong Ong)
    {
        WriteRepository.Update(Ong);
    }

    public void DeleteById(int id)
    {
        WriteRepository.DeleteById(id);
    }
}