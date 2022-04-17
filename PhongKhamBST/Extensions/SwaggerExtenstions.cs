using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKhamBST.Extensions
{
    public static class SwaggerExtenstions
    {
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "MyAPI",
                    Description = "Testing",

                });
                c.AddSecurityDefinition(ApiKeyAuthenticationOptions.DefaultScheme, new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Name = ApiKeyAuthenticationOptions.HeaderKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insert Jwt Token",

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                     {
                         new OpenApiSecurityScheme
                         {
                             Reference = new OpenApiReference
                             {
                                 Type = ReferenceType.SecurityScheme,
                                   Id = ApiKeyAuthenticationOptions.DefaultScheme
                             },
                         },
                         new string[] { }
                     }
                 });
            });

        }
    }
}
