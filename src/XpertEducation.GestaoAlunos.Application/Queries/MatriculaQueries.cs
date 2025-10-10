using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.Queries;

public class MatriculaQueries : IMatriculaQueries
{
    private readonly IAlunoRepository _alunoRepository;

    public MatriculaQueries(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<MatriculaViewModel> ObterMatriculaAluno(Guid alunoId)
    {
        var matricula = await _alunoRepository.ObterMatriculaPorAlunoId(alunoId);
        return new MatriculaViewModel { 
            Id = matricula.Id,
            AlunoId = matricula.AlunoId,
            CursoId = matricula.CursoId,
            Status = matricula.MatriculaStatus,
        };
    }
}
