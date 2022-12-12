﻿using Aplication.Utils.Obj;

namespace Aplication.Models.Response.Endereco;

public class EnderecoResponse : ValidationResult
{ 
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string Rua { get; set; } = null!;
    public bool StatusApi { get; set; }
}