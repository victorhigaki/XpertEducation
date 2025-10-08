using XpertEducation.Core.Data;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Business.Interfaces;

public interface IPagamentoRepository : IRepository<Pagamento>
{
    void Adicionar(Pagamento pagamento);
    void AdicionarTransacao(Transacao transacao);
}
