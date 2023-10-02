using PPA.Business.Models;
using PPA.Data.Repository;
using FilaVirtual.Business.Models;
using MSSUPERA.Business.Models;
using FilaVirtual.Business.Interfaces.Repository;

public class LogAtividadeRepository : Repository<LogAtividade>, ILogAtividadeRepository
{
	public LogAtividadeRepository(FilaVirtual_Context context) : base(context)
	{

	}
}