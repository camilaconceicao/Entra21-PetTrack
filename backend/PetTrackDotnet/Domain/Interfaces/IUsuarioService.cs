using Infra.Data.Entity;

namespace Domain.Interfaces;

public interface IUsuarioService
{
    public Usuario GetById(int id);
    public Usuario? GetByCpf(string cpf);
    public List<Usuario> GetAllList();
    public IQueryable<Usuario> GetAllQuery();
    public void Cadastrar(Usuario usuarioEntity);
    public void Editar(Usuario usuario);
    public void DeleteById(int id);
    public Usuario CadastrarComRetorno(Usuario usuario);
}