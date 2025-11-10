using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Domain.Entities.Common;
using ZenBlog.Persistance.Context;

namespace ZenBlog.Persistance.Concrete
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity>_table= _context.Set<TEntity>();
        public async Task CreateAsync(TEntity entity)
        {
             await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _table; 
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entity)
        {
           _context.Update(entity);
            
        }
    }
}
