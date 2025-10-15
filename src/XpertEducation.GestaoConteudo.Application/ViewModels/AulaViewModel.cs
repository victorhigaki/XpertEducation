namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public class AulaViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CursoId { get; set; }
    public string ConteudoAula { get; set; }
    public string Titulo { get; set; }
    public string? Material { get; set; } = null;
}
