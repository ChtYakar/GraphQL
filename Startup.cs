using GraphiQl;
using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL_Nsn.Graph.Mutation;
using GraphQL_Nsn.Graph.Query;
using GraphQL_Nsn.Graph.Schema;
using GraphQL_Nsn.Graph.Type;
using GraphQL_Nsn.Interfaces;
using GraphQL_Nsn.Repositories;
using GraphQL_Nsn.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace GraphQL_Nsn
{
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
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFieldService, FieldService>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<MainMutation>();
            services.AddScoped<MainQuery>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<LiveScoreSchema>();

            services.AddControllers();
            services.AddSingleton<StastisticsGType>();
            services.AddSingleton<MatchesGType>();
            services.AddSingleton<TeamGType>();
            services.AddSingleton<PlayerGType>();

          

            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddGraphiQl(x =>
            {
                x.GraphiQlPath = "/graphiql-ui";
                x.GraphQlApiPath = "/graphql";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL_Nsn v1"));
            }
            app.UseCors(builder =>
           builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQl();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
