using Aplication.Models.Request.Pet;
using Aplication.Utils.Obj;
using Aplication.Utils.ValidatorDocument;

namespace Aplication.Validators.Pet;

public class PetValidator : IPetValidator
{
    protected readonly IValidatorDocument Util;
    public PetValidator(IValidatorDocument utilDocument)
    {
        Util = utilDocument;
    }

    public ValidationResult ValidaçãoCadastro(PetRequest request)
    {
        var validation = new ValidationResult();
        
        if(string.IsNullOrEmpty(request.Bairro))
            validation.LErrors.Add("Campo Bairro é obrigatório!");
        if(string.IsNullOrEmpty(request.Cep))
            validation.LErrors.Add("Campo Cep é obrigatório!");
        if(string.IsNullOrEmpty(request.Nome))
            validation.LErrors.Add("Campo nome é obrigatório!");
        if(string.IsNullOrEmpty(request.Descricao))
            validation.LErrors.Add("Campo Descricao é obrigatório!");
        if(string.IsNullOrEmpty(request.Cidade))
            validation.LErrors.Add("Campo Cidade é obrigatório!");
        if(string.IsNullOrEmpty(request.Raca))
            validation.LErrors.Add("Campo Raca é obrigatório!");
        if(string.IsNullOrEmpty(request.Rua))
            validation.LErrors.Add("Campo Rua é obrigatório!");
        if(string.IsNullOrEmpty(request.FotoBase64))
            validation.LErrors.Add("Campo FotoBase64 é obrigatório!");
        if(!request.UsuarioCadastroId.HasValue)
            validation.LErrors.Add("Usuário nao encontrado!");

        return validation;    
    }
}