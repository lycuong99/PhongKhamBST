using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhongKhamBST.Extensions;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Data.ViewModels;
using Newtonsoft.Json;
using Services.Helper;
using Microsoft.AspNetCore.Authentication;
using Data.Query;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Data.GraphQL.Types;

namespace PhongKhamBST
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
        public const string HeaderKey = "Authorization";
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            if (FirebaseApp.DefaultInstance == null)
            {
                var fbconfig = new FirebaseConfig();
                Configuration.Bind("Firebase", fbconfig);

                var json = JsonConvert.SerializeObject(fbconfig);

                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(json)
                });
            }

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddControllers();
            services.ConfgiCORS();
           

            services.ConfigDbContext(Configuration["ConnectionStrings:DbConnection"]);
            services.BusinessServices();
            services.ConfigSwagger();

            services.ConfigJwt(Configuration);

            services.AddGraphQLServer().AddQueryType<Query>().AddType<UserType>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/graphql",
                    Path = "/playground"
                });
            }

            app.UseHttpsRedirection();
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseSwagger();

         

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

          /*  app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");*/
        }
    }
}
