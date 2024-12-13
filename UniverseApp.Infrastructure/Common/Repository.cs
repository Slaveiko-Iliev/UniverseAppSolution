using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UniverseApp.Infrastructure.Data;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Infrastructure.Common
{
	public class Repository : IRepository
	{
		private readonly UniverseDbContext _context;

		public Repository(UniverseDbContext context)
		{
			_context = context;
		}

		private DbSet<TEntity> DbSet<TEntity>() where TEntity : class
		{
			return _context.Set<TEntity>();
		}

		public IQueryable<TEntity> All<TEntity>() where TEntity : class
		{
			return DbSet<TEntity>();
		}

		public IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class
		{
			return DbSet<TEntity>()
				.AsNoTracking();
		}

		public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
		{
			await DbSet<TEntity>()
				.AddAsync(entity);
		}

		public async Task<int> SaveChangesAsync() =>
			await _context.SaveChangesAsync();

		private IQueryable<TEntity> ApplyIncludes<TEntity>(IQueryable<TEntity> query) where TEntity : class
		{
			var includeAttributes = typeof(TEntity).GetCustomAttributes<IncludeAttribute>();
			foreach (var includeAttribute in includeAttributes)
			{
				query = query.Include(includeAttribute.NavigationProperty);
			}
			return query;
		}

		public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id) where TEntity : class
		{
			var query = ApplyIncludes(DbSet<TEntity>());
			return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
		}

		public async Task<List<KeyValuePair<string, EntityNameDto>>> GetEntitiesNames<TEntity>(ICollection<TEntity> characters) where TEntity : class
		{
			return await DbSet<TEntity>()
				.Where(x => characters.Contains(x))
				.Select(x => new KeyValuePair<string, EntityNameDto>
					(typeof(TEntity).Name,
					new EntityNameDto
					{
						Id = EF.Property<int>(x, "Id"),
						Name = EF.Property<string>(x, "Name")
					}))
				.ToListAsync();
		}
	}
}
