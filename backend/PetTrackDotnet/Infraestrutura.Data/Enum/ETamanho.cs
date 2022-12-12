using System.ComponentModel;

namespace Infraestrutura.Enum;

public enum ETamanho
{
    [Description("Pequeno")]
    Pequeno = 0,
    [Description("Medio")]
    Medio = 1,
    [Description("Grande")]
    Grande = 2
}