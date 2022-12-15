using Domain.Interfaces;
using Infra.Data.Entity;
using Infra.Data.Repository.Interface.Usuario;

namespace Domain.Services;

public class UsuarioService : IUsuarioService
{
    protected readonly IUsuarioReadRepository ReadRepository;
    protected readonly IUsuarioWriteRepository WriteRepository;

    public UsuarioService(IUsuarioReadRepository readRepository,IUsuarioWriteRepository writeRepository)
    {
        ReadRepository = readRepository;
        WriteRepository = writeRepository;
    }

    public Usuario GetById(int id)
    {
        return ReadRepository.GetById(id);
    }

    public Usuario? GetByCpf(string cpf)
    {
        return ReadRepository.GetAll().FirstOrDefault(x => x.Cpf == cpf);
    }

    public List<Usuario> GetAllList()
    {
        return ReadRepository.GetAll().ToList();
    }
    
    public IQueryable<Usuario> GetAllQuery()
    {
        return ReadRepository.GetAll();
    }

    public void Cadastrar(Usuario usuario)
    {
        WriteRepository.Add(usuario);
    }
    
    public Usuario CadastrarComRetorno(Usuario usuario)
    {
        return WriteRepository.AddWithReturn(usuario);
    }

    public void Editar(Usuario usuario)
    {
        WriteRepository.Update(usuario);
    }

    public void DeleteById(int id)
    {
        WriteRepository.DeleteById(id);
    }
}