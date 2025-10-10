namespace XpertEducation.GestaoAlunos.Domain.Models;

public class HistoricoAprendizado
{
    public Guid AulaId { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public HistoricoAprendizado(Guid aulaId)
    {
        AulaId = aulaId;
        DataCadastro = DateTime.Now;
    }
}