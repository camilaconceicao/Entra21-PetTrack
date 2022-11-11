namespace Aplication.Utils.Obj;

public class ValidationResult
{
    public List<string> LErrors { get; }
    
    public ValidationResult()
    {
        LErrors = new List<string>();
    }

    public bool IsValid()
    {
        return !LErrors.Any();
    }
} 
