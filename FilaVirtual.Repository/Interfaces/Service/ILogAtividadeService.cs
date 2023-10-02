using FilaVirtual.Business.Models;
using System.Linq.Expressions;

namespace FilaVirtual.Business.Interfaces.Service
{
    public interface ILogAtividadeService : IDisposable
    {
        Task<IEnumerable<LogAtividade>> Buscar(Expression<Func<LogAtividade, bool>> predicate);
        Task Adicionar(LogAtividade proposta);
    }

}