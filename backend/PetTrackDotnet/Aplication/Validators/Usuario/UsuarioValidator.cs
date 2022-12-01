using Aplication.Models.Request.Usuario;
using Aplication.Utils.Obj;
using Aplication.Utils.ValidatorDocument;

namespace Aplication.Validators.Usuario;

public class UsuarioValidator : IUsuarioValidator
{
    protected readonly IValidatorDocument Util;
    public UsuarioValidator(IValidatorDocument utilDocument)
    {
        Util = utilDocument;
    }

    public ValidationResult ValidaçãoCadastro(UsuarioRequest request)
    {
        var validation = new ValidationResult();
        
        if(string.IsNullOrEmpty(request.Email))
            validation.LErrors.Add("Campo Email é obrigatório!");
        if(string.IsNullOrEmpty(request.Telefone))
            validation.LErrors.Add("Campo Email é obrigatório!");
        if(string.IsNullOrEmpty(request.Nome))
            validation.LErrors.Add("Campo nome é obrigatório!");
        if(string.IsNullOrEmpty(request.Cpf))
            validation.LErrors.Add("Campo CPF é obrigatório!");
        if(!Util.ValidatorCpf(request.Cpf ?? string.Empty))
            validation.LErrors.Add("Campo CPF inválido!");
        if(!request.DataNascimento.HasValue)
            validation.LErrors.Add("Campo data de nascimento é obrigatório!");
        if(string.IsNullOrEmpty(request.Senha))
            validation.LErrors.Add("Campo senha é obrigatório!");

        return validation;    
    }
}