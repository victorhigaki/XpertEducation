using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoAlunos.Domain.Models
{
    public class Certificado : Entity
    {
        public Guid AlunoId { get; private set; }
        public Guid CursoId { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public Certificado(Guid alunoId, Guid cursoId, DateTime dataEmissao)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
            DataEmissao = dataEmissao;
        }
    }
}