using XpertEducation.GestaoAlunos.Application.ViewModels;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.Queries;

public class AlunoQuery : IAlunoQuery
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoQuery(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<AlunoViewModel> ObterPorId(Guid id)
    {
        var aluno = await _alunoRepository.ObterPorId(id);

        return new AlunoViewModel
        {
            Id = aluno.Id,
            HistoricoAprendizado = aluno.HistoricoAprendizado.Select(h => new HistoricoAprendizadoViewModel
            {
                AulaId = h.AulaId
            })
        };
    }
}
