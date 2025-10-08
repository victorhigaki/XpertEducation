using XpertEducation.Core.Data;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Data.Repositories;

public class PagamentoRepository : IPagamentoRepository
{
    private readonly PagamentoContext _context;

    public PagamentoRepository(PagamentoContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void Adicionar(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
