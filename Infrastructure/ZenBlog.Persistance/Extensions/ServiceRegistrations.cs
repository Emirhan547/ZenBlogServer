using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenBlog.Application.Contracts.Persistance;
using ZenBlog.Persistance.Concrete;
using ZenBlog.Persistance.Context;

namespace ZenBlog.Persistance.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceServices( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
        }
    }
}
