using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands
{
    internal class MatriculaRealizadaEvent : Event
    {
        private Guid id;
        private Guid cursoId;
        private Guid alunoId;

        public MatriculaRealizadaEvent(Guid id, Guid cursoId, Guid alunoId)
        {
            this.id = id;
            this.cursoId = cursoId;
            this.alunoId = alunoId;
        }
    }
}