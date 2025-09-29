﻿namespace XpertEducation.GestaoConteudo.Domain;

public class ConteudoProgramatico
{
    public string? Objetivo { get; private set; }
    public string? Conteudo { get; private set; }
    public string? Metodologia { get; private set; }
    public string? Bibliografia { get; private set; }

    public ConteudoProgramatico(string objetivo, string conteudo, string metodologia, string bibliografia)
    {
        Objetivo = objetivo;
        Conteudo = conteudo;
        Metodologia = metodologia;
        Bibliografia = bibliografia;
    }
}
