using Aplication.Models.Request.Ong;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Validators.Ong;

public interface IOngValidator
{
    public ValidationResult ValidaçãoCadastro(OngRequest request);
}