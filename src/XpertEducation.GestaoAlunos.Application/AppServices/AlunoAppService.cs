using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.AppServices;

public class AlunoAppService : IAlunoAppService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoAppService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task AdicionarAsync(AlunoViewModel alunoViewModel)
    {
        var aluno = new Aluno(alunoViewModel.Id);
        _alunoRepository.Adicionar(aluno);
        await _alunoRepository.UnitOfWork.Commit();
    }

    public async Task<MatriculaViewModel> ObterMatriculaPorAlunoId(Guid matriculaId)
    {
        var matricula = await _alunoRepository.ObterMatriculaPorAlunoId(matriculaId);
        return new MatriculaViewModel {
            Id = matricula.Id,
            AlunoId = matricula.AlunoId,
            CursoId = matricula.CursoId,
            Status = matricula.MatriculaStatus
        };
    }

    public void Dispose()
    {
        _alunoRepository.Dispose();
    }
}
