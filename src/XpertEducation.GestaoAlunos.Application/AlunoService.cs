using XpertEducation.GestaoAlunos.Data;
using XpertEducation.GestaoAlunos.Domain;

namespace XpertEducation.GestaoAlunos.Application;

public class AlunoAppService : IAlunoAppService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoAppService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task Adicionar(AlunoViewModel alunoViewModel)
    {
        var aluno = new Aluno(alunoViewModel.Id);
        await _alunoRepository.Adicionar(aluno);
        await _alunoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _alunoRepository.Dispose();
    }
}
