using Infra.Data.Entity;

namespace Domain.Interfaces;

public interface ICareService
{
    public Care GetById(int id);
    public List<Care> GetAllList();
    public IQueryable<Care> GetAllQuery();
    public void Cadastrar(Care CareEntity);
    public void Editar(Care Care);
    public void DeleteById(int id);
    public Care CadastrarComRetorno(Care Care);
}