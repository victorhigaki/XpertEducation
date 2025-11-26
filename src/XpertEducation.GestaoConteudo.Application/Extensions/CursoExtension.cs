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
            Valor = curso.Valor
        };
    }
}
