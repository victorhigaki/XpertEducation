using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.Extensions;

public static class AulaExtension
{
    public static AulaViewModel ToViewModel(this Aula aula)
    {
        return new AulaViewModel
        {
            Id = aula.Id,
            ConteudoAula = aula.ConteudoAula,
            Titulo = aula.Titulo,
            Material = aula.Material,
            CursoId = aula.CursoId,
            Curso = aula.Curso.ToViewModel()
        };
    }

    public static IEnumerable<AulaViewModel> ToViewModel(this IEnumerable<Aula> aulas)
    {
        return aulas.Select(aula => aula.ToViewModel());
    }

    public static Aula ToModel(this AulaViewModel aula)
    {
        return new Aula(
            aula.CursoId,
            aula.Titulo,
            aula.ConteudoAula,
            aula.Material
        );
    }

    public static IEnumerable<Aula> ToModel(this IEnumerable<AulaViewModel> aulas)
    {
        return aulas.Select(aula => aula.ToModel());
    }
}
