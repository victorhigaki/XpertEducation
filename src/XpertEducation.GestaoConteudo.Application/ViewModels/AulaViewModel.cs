namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public class AulaViewModel
{
    public required Guid CursoId { get; set; }
    public required string ConteudoAula { get; set; }
    public required string Titulo { get; set; }
    public string? Material { get; set; } = null;
}
