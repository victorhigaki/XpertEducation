using System.ComponentModel.DataAnnotations;

namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public class CursoViewModel
{
    public required string Nome { get; set; }
    public required string ConteudoProgramatico { get; set; }
}
