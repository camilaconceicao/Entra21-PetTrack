using System.ComponentModel;

namespace Infraestrutura.Enum;

public enum Operador
{
    [Description("Asc")]
    Ascending = 0,
    [Description("Desc")]
    Descending = 1,
}