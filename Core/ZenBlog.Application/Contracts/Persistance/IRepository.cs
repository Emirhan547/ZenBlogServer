using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Application.Contracts.Persistance
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task <List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetQuery();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetSingleAsync(Expression <Func<TEntity, bool>> filter);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
