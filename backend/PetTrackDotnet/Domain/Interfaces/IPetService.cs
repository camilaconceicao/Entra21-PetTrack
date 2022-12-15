using Infra.Data.Entity;

namespace Domain.Interfaces;

public interface IPetService
{
    public Pet GetById(int id);
    public List<Pet> GetAllList();
    public IQueryable<Pet> GetAllQuery();
    public void Cadastrar(Pet petEntity);
    public void Editar(Pet pet);
    public void DeleteById(int id);
    public Pet CadastrarComRetorno(Pet pet);
}