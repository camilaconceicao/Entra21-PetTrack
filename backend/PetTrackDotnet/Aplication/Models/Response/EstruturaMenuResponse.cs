﻿namespace Aplication.Models.Response;

public class EstrututuraMenuResponse
{
    public List<ModuloResponse> lModulos { get; set; }
}

public class ModuloResponse
{
    public string Nome { get; set; }
    public string Icone { get; set; }
    public string DescricaoLabel { get; set; }
    public List<LMenu> lMenus { get; set; }
}
public class LMenu
{
    public string Nome { get; set; }
    public string Link { get; set; }
}

