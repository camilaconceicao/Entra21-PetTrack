using Aplication.Models.Request.Care;
using Aplication.Utils.Obj;

namespace Aplication.Validators.Care;

public class CareValidator : ICareValidator
{
    public ValidationResult ValidaçãoCadastro(CareRequest request)
    {
        var validation = new ValidationResult();
        
        if(string.IsNullOrEmpty(request.Nome))
            validation.LErrors.Add("Campo nome é obrigatório!");
        if(string.IsNullOrEmpty(request.Descricao))
            validation.LErrors.Add("Campo Descricao é obrigatório!");
        if(string.IsNullOrEmpty(request.FotoBase64))
            validation.LErrors.Add("Campo FotoBase64 é obrigatório!");

        return validation;    
    }
}