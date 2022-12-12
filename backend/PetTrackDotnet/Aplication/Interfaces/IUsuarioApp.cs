using Aplication.Models.Request.Usuario;
using Aplication.Models.Response;
using Aplication.Models.Response.Usuario;
using Infraestrutura.Entity;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Interfaces;

public interface IUsuarioApp
{
    public List<Usuario> GetAll();
    public Usuario? GetByCpf(string cpf);
    public Usuario GetById(int id);
    public UsuarioCadastroResponse Cadastrar(UsuarioRequest request);
    public void Editar(Usuario usuario);
    public void DeleteById(int id);
}