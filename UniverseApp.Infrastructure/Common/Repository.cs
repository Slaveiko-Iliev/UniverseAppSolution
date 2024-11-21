using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseApp.Infrastructure.Data;

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

        public async Task<TEntity> GetEntityByIdAsync<TEntity>(int id) where TEntity : class =>
            (await DbSet<TEntity>()
                .FindAsync(id))!;
    }
}
