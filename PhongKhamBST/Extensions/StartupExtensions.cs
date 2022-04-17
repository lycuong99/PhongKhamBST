using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Services.Interfaces;
using Services.Implementations;

namespace PhongKhamBST.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigDbContext(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnection));
        }
        public static void BusinessServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthService, AuthService>();
        }
        public static void ConfgiCORS(this IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
        }
    }
}
