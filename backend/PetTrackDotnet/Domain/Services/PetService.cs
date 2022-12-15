using Domain.Interfaces;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Pet;

namespace Domain.Services;

public class PetService : IPetService
{
    protected readonly IPetReadRepository ReadRepository;
    protected readonly IPetWriteRepository WriteRepository;

    public PetService(IPetReadRepository readRepository,IPetWriteRepository writeRepository)
    {
        ReadRepository = readRepository;
        WriteRepository = writeRepository;
    }

    public Pet GetById(int id)
    {
        return ReadRepository.GetById(id);
    }
    
    public List<Pet> GetAllList()
    {
        return ReadRepository.GetAll().ToList();
    }
    
    public IQueryable<Pet> GetAllQuery()
    {
        return ReadRepository.GetAll();
    }

    public void Cadastrar(Pet pet)
    {
        WriteRepository.Add(pet);
    }
    
    public Pet CadastrarComRetorno(Pet pet)
    {
        return WriteRepository.AddWithReturn(pet);
    }

    public void Editar(Pet pet)
    {
        WriteRepository.Update(pet);
    }

    public void DeleteById(int id)
    {
        WriteRepository.DeleteById(id);
    }
}