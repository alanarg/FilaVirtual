using PPA.Business.Models;
using System.Linq.Expressions;
using FilaVirtual.Business.Interfaces.Service;
using FilaVirtual.Business.Interfaces.Repository;
using FilaVirtual.Business.Interfaces;
using FilaVirtual.Business.Models;

namespace FilaVirtual.Business.Services
{
	public class LogAtividadeService : BaseService, ILogAtividadeService
	{
		private readonly ILogAtividadeRepository _logAtividadeRepository;

		public LogAtividadeService(
			INotificador notificador,
            ILogAtividadeRepository logAtividadeRepository
            ) : base(notificador)
		{
            _logAtividadeRepository = logAtividadeRepository;
		}

		public async Task<IEnumerable<LogAtividade>> Buscar(Expression<Func<LogAtividade, bool>> predicate)
		{
			return await _logAtividadeRepository.Buscar(predicate);
		}

		public async Task Adicionar(LogAtividade logAtividade)
		{			
			await _logAtividadeRepository.Adicionar(logAtividade);

		}

		public void Dispose()
		{
            _logAtividadeRepository?.Dispose();
		}
	}
}
