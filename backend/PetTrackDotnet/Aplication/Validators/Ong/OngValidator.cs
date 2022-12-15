using Aplication.Models.Request.Ong;
using Aplication.Utils.Obj;

namespace Aplication.Validators.Ong;

public class OngValidator : IOngValidator
{
    public ValidationResult ValidaçãoCadastro(OngRequest request)
    {
        var validation = new ValidationResult();
        
        if(string.IsNullOrEmpty(request.Email))
            validation.LErrors.Add("Campo Email é obrigatório!");
        if(string.IsNullOrEmpty(request.Pix))
            validation.LErrors.Add("Campo Pix é obrigatório!");
        if(string.IsNullOrEmpty(request.Nome))
            validation.LErrors.Add("Campo nome é obrigatório!");
        if(string.IsNullOrEmpty(request.RazaoSocial))
            validation.LErrors.Add("Campo RazaoSocial é obrigatório!");
        if(string.IsNullOrEmpty(request.Descricao))
            validation.LErrors.Add("Campo Descricao é obrigatório!");
        if(string.IsNullOrEmpty(request.FotoBase64))
            validation.LErrors.Add("Campo FotoBase64 é obrigatório!");

        return validation;    
    }
}