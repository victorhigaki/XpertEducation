using XpertEducation.Core.DomainObjects;
using XpertEducation.GestaoAlunos.Domain.Enums;

namespace XpertEducation.GestaoAlunos.Domain.Models;

public class Matricula : Entity
{
    public Guid AlunoId { get; set; }
    public Guid CursoId { get; set; }

    public MatriculaStatus Status { get; set; }

    public Matricula() { }

    public Matricula(Guid alunoId, Guid cursoId)
    {
        Id = Guid.NewGuid();
        AlunoId = alunoId;
        CursoId = cursoId;
        Status = MatriculaStatus.PendentePagamento;
        Validar();
    }

    public void MatriculaPaga()
    {
        Status = MatriculaStatus.Pago;
    }

    private void Validar()
    {
        Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId não pode estar vazio");
        Validacoes.ValidarSeIgual(AlunoId, Guid.Empty, "O campo AlunoId não pode estar vazio");
    }
}