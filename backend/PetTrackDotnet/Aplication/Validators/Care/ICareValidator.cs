using Aplication.Models.Request.Care;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Validators.Care;

public interface ICareValidator
{
    public ValidationResult ValidaçãoCadastro(CareRequest request);
}