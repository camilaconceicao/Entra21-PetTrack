using Aplication.Models.Request.Care;
using Infra.Data.Entity;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Interfaces;

public interface ICareApp
{
    public List<Care> GetAll();
    public Care GetById(int id);
    public ValidationResult Cadastrar(CareRequest request);
    public ValidationResult Editar(CareRequest request);
    public void DeleteById(int id);
}