using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;

namespace PhongKhamBST.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigDbContext(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnection));
        }
    }
}
