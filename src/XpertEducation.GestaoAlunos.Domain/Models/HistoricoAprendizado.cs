using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoAlunos.Domain.Models;

public class HistoricoAprendizado : Entity
{
    public Guid AlunoId { get; set; }
    public Guid AulaId { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public Aluno Aluno { get; set; }

    protected HistoricoAprendizado()
    {
    }

    public HistoricoAprendizado(Guid alunoId, Guid aulaId)
    {
        AlunoId = alunoId;
        AulaId = aulaId;
        DataCadastro = DateTime.Now;
    }
}