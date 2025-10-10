namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public class CursoViewModel
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string ConteudoProgramatico { get; set; }
    public required decimal Valor { get; set; }
}
