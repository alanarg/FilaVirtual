using FilaVirtual.Business.Interfaces.Repository;
using FilaVirtual.Business.Models;
using Microsoft.EntityFrameworkCore;
using MSSUPERA.Business.Models;
using PPA.Business.Models;
using System.Linq.Expressions;

namespace PPA.Data.Repository
{
	public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
	{
		protected readonly FilaVirtual_Context Db;
		protected readonly DbSet<TEntity> DbSet;

		protected Repository(FilaVirtual_Context db)
		{
			Db = db;
			DbSet = db.Set<TEntity>();
		}

		public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
		}

		public virtual async Task Adicionar(TEntity entity)
		{
			try
			{
				DbSet.Add(entity);
				await SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task Atualizar(TEntity entity)
		{
			try
			{
				DbSet.Update(entity);
				await SaveChanges();

			}
			catch (Exception e)
			{
				throw e;
			}
		}

        public virtual async Task<TEntity> ObterPorID(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
		{
			try
			{
				return await DbSet.ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual async Task Remover(int id)
		{
			TEntity entity = new TEntity();
			entity.SetId(id);
			DbSet.Remove(entity);
			await SaveChanges();
		}

		public async Task<int> SaveChanges()
		{
			return await Db.SaveChangesAsync();
		}

		public virtual void Dispose()
		{
			Db?.DisposeAsync();
		}

	}
}
