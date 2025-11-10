using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Persistance.Context;

namespace ZenBlog.Persistance.Concrete
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
