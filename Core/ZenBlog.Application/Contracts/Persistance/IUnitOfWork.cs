using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenBlog.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
