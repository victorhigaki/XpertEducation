namespace XpertEducation.GestaoAlunos.Application;

public interface IAlunoAppService : IDisposable
{
    Task Adicionar(AlunoViewModel alunoViewModel);
}