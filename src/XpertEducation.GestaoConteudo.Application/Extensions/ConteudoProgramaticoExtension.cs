using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.Extensions;

public static class ConteudoProgramaticoExtension
{
    public static ConteudoProgramaticoViewModel ToViewModel(this ConteudoProgramatico curso)
    {
        return new ConteudoProgramaticoViewModel
        {
            Objetivo = curso.Objetivo,
            Conteudo = curso.Conteudo,
            Metodologia = curso.Metodologia,
            Bibliografia = curso.Bibliografia
        };
    }

    public static IEnumerable<ConteudoProgramaticoViewModel> ToViewModel(this IEnumerable<ConteudoProgramatico> cursos)
    {
        return cursos.Select(curso => curso.ToViewModel());
    }

    public static ConteudoProgramatico ToModel(this ConteudoProgramaticoViewModel curso)
    {
        return new ConteudoProgramatico(
            curso.Objetivo,
            curso.Conteudo,
            curso.Metodologia,
            curso.Bibliografia
        );
    }
}
