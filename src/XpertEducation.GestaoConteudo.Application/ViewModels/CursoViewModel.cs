namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public record CursoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public ConteudoProgramaticoViewModel ConteudoProgramatico { get; set; }
    public decimal Valor { get; set; }
    public IEnumerable<AulaViewModel> Aulas { get; set; }
}
