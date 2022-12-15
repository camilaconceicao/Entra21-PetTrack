using Aplication.Models.Request.Ong;
using Infra.Data.Entity;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Interfaces;

public interface IOngApp
{
    public List<Ong> GetAll();
    public Ong GetById(int id);
    public ValidationResult Cadastrar(OngRequest request);
    public ValidationResult Editar(OngRequest request);
    public void DeleteById(int id);
}