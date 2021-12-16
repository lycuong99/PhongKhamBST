using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace PhongKhamBST.Extensions
{
    public static class JwtExtenstions
    {
        public static void ConfigJwt(this IServiceCollection services, IConfiguration configuration)
        {

            //Firebase Auth
            services.AddAuthorization().AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer("Firebase",
                opt =>
                {
                    opt.SaveToken = true;
                    opt.Authority = configuration["Jwt:Firebase:ValidIssuer"];
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Firebase:ValidIssuer"],
                        ValidAudience = configuration["Jwt:Firebase:ValidAudience"]
                    };
                });

            //Custom Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer("AuthCustom", opt =>
           {
               opt.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["Jwt:AuthCustom:ValidIssuer"],
                   ValidAudience = configuration["Jwt:AuthCustom:ValidAudience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:AuthCustom:Key"]))
               };
           });
    
            services.AddAuthorization(opt =>
            {
                opt.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes("Firebase", "AuthCustom")
                .RequireAuthenticatedUser()
                .Build();
            });

        }
    }
}
