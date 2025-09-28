using System.ComponentModel.DataAnnotations;

namespace XpertEducation.GestaoConteudo.Application.ViewModels;

public class CursoViewModel
{
    [Required]
    public string Nome { get; set; }
}
