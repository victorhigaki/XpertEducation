using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class ConteudoProgramatico
{
    public string Objetivo { get; private set; }
    public string Conteudo { get; private set; }
    public string Metodologia { get; private set; }
    public string Bibliografia { get; private set; }

    public ConteudoProgramatico()
    {
        
    }

    public ConteudoProgramatico(string objetivo, string conteudo, string metodologia, string bibliografia)
    {
        Objetivo = objetivo;
        Conteudo = conteudo;
        Metodologia = metodologia;
        Bibliografia = bibliografia;

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Objetivo, "O campo Objetivo não pode estar vazio");
        Validacoes.ValidarSeVazio(Conteudo, "O campo Conteudo não pode estar vazio");
        Validacoes.ValidarSeVazio(Metodologia, "O campo Metodologia não pode estar vazio");
        Validacoes.ValidarSeVazio(Bibliografia, "O campo Bibliografia não pode estar vazio");
    }
}
