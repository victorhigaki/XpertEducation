using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.Extensions;

public static class CursoExtension
{
    public static CursoViewModel ToViewModel(this Curso curso)
    {
        return new CursoViewModel {
            Id = curso.Id,
            Nome = curso.Nome,
            ConteudoProgramatico = curso.ConteudoProgramatico.ToViewModel(),
            Valor = curso.Valor,
            Aulas = curso.Aulas.ToViewModel(),
        };
    }

    public static IEnumerable<CursoViewModel> ToViewModel(this IEnumerable<Curso> cursos)
    {
        return cursos.Select(curso => curso.ToViewModel());
    }

    public static Curso ToModel(this CursoViewModel curso)
    {
        return new Curso(
            curso.Nome,
            curso.ConteudoProgramatico.ToModel(),
            curso.Valor
        );
    }

    public static IEnumerable<Curso> ToModel(this IEnumerable<CursoViewModel> cursos)
    {
        return cursos.Select(curso => curso.ToModel());
    }
}
