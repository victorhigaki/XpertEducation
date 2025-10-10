using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoAlunos.Domain.Models;

public class Aluno : Entity, IAggregateRoot
{
    public ICollection<Matricula> Matriculas { get; private set; }
    public ICollection<Certificado> Certificados { get; private set; }
    public ICollection<HistoricoAprendizado> HistoricoAprendizado { get; private set; }

    public DateTime DataCadastro { get; set; }

    public Aluno(Guid id)
    {
        Id = id;

        Matriculas = new List<Matricula>();
        Certificados = new List<Certificado>();
    }

    public void RealizarAula(Guid aulaId)
    {
        HistoricoAprendizado.Add(new HistoricoAprendizado(aulaId));
    }
}
