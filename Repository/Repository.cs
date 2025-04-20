using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes.Data;
using Classes.Interfaces;
using Classes.Models;
using Microsoft.EntityFrameworkCore;

namespace Classes.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : ModelBase
    {
    private readonly DataContext _context;
    protected readonly DbSet<TEntity> _entities;

    public Repository(DataContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var _ = await _entities.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _entities.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return result;
        }
        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);

            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}