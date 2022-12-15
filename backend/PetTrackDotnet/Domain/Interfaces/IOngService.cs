using Infra.Data.Entity;

namespace Domain.Interfaces;

public interface IOngService
{
    public Ong GetById(int id);
    public List<Ong> GetAllList();
    public IQueryable<Ong> GetAllQuery();
    public void Cadastrar(Ong OngEntity);
    public void Editar(Ong Ong);
    public void DeleteById(int id);
    public Ong CadastrarComRetorno(Ong Ong);
}