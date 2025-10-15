using XpertEducation.Core.DomainObjects;
using XpertEducation.GestaoAlunos.Domain.Enums;

namespace XpertEducation.GestaoAlunos.Domain.Models;

public class Matricula : Entity
{
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }
    public decimal Valor { get; private set; }

    public MatriculaStatus MatriculaStatus { get; private set; }

    protected Matricula() { }

    public Matricula(Guid alunoId, Guid cursoId, decimal valor)
    {
        Id = Guid.NewGuid();
        AlunoId = alunoId;
        CursoId = cursoId;
        Valor = valor;
        MatriculaStatus = MatriculaStatus.PendentePagamento;
        Validar();
    }

    public void AbrirNovaMatricula()
    {
        MatriculaStatus = MatriculaStatus.PendentePagamento;
    }

    public void Iniciar()
    {
        MatriculaStatus = MatriculaStatus.Iniciado;
    }

    public void Finalizar()
    {
        MatriculaStatus = MatriculaStatus.Pago;
    }

    public void Recusar()
    {
        MatriculaStatus = MatriculaStatus.Recusado;
    }

    public void AlterarCurso(Guid cursoId)
    {
        CursoId = cursoId;
    }

    private void Validar()
    {
        Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId não pode estar vazio");
        Validacoes.ValidarSeIgual(AlunoId, Guid.Empty, "O campo AlunoId não pode estar vazio");
        Validacoes.ValidarSeIgual(Valor, string.Empty, "O campo Valor não pode estar vazio");
    }

    public void FinalizarCurso()
    {
        MatriculaStatus = MatriculaStatus.Concluido;
    }

    public static class MatriculaFactory
    {
        public static Matricula NovaMatricula(Guid alunoId, Guid cursoId)
        {
            var matricula = new Matricula
            {
                AlunoId = alunoId,
                CursoId = cursoId,
            };

            return matricula;
        }
    }
}