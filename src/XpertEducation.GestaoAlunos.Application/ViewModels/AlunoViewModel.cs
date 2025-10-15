using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Application.ViewModels;

public class AlunoViewModel
{
    public Guid Id { get; set; }
    
    public IEnumerable<HistoricoAprendizadoViewModel> HistoricoAprendizado { get; set; }
}
