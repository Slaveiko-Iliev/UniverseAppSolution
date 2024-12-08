﻿namespace UniverseApp.Infrastructure.Common
{
	public interface IRepository
	{
		IQueryable<TEntity> All<TEntity>() where TEntity : class;

		IQueryable<TEntity> AllReadOnly<TEntity>() where TEntity : class;

		Task AddAsync<TEntity>(TEntity entity) where TEntity : class;

		Task<int> SaveChangesAsync();

		Task<TEntity> GetEntityByIdAsync<TEntity>(int id) where TEntity : class;

		Task<List<string>> GetEntitiesNames<TEntity>(ICollection<TEntity> characters) where TEntity : class;
	}
}
