using XpertEducation.GestaoAlunos.Domain.Enums;

namespace XpertEducation.GestaoAlunos.Application.ViewModels;

public class MatriculaViewModel
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public required Guid CursoId { get; set; }
    public MatriculaStatus Status { get; set; }
}