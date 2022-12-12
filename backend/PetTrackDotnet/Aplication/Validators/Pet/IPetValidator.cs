using Aplication.Models.Request.Pet;
using ValidationResult = Aplication.Utils.Obj.ValidationResult;

namespace Aplication.Validators.Pet;

public interface IPetValidator
{
    public ValidationResult ValidaçãoCadastro(PetRequest request);
}