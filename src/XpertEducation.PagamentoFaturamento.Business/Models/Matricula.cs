namespace XpertEducation.PagamentoFaturamento.Business.Models
{
    public class Matricula
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}