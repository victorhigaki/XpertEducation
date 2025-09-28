using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface ICursoAppService : IDisposable
{
    Task CriarCurso(CursoViewModel cursoViewModel);
}
