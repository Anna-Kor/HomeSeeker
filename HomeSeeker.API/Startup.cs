using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json.Serialization;

using Data;

using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Authorization;
using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Models;
using HomeSeeker.API.Queries;
using HomeSeeker.API.Queries.UserQueries;
using HomeSeeker.API.Repositories.HomeRepositories;
using HomeSeeker.API.Repositories.UserRepositories;

using MediatR;

using System.Reflection;
using System.Collections.Generic;
using NSwag;
using NSwag.Generation.Processors.Security;
using HomeSeeker.API.Commands.HomeCommands;
using HomeSeeker.API.Queries.HomeQueries;
using System.Linq;

namespace HomeSeeker.API
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
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //JSON Serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<JwtMiddleware>();

            services.AddScoped<IRequestHandler<RegisterUserCommand>, UsersCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllUsersQuery, List<UserModel>>, UsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, UserModel>, UsersQueryHandler>();
            services.AddScoped<IRequestHandler<AuthenticateQuery, AuthenticateResponse>, UsersQueryHandler>();

            services.AddScoped<IRequestHandler<AddHomeCommand>, HomesCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteHomeCommand>, HomesCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateHomeCommand>, HomesCommandHandler>();
            services.AddScoped<IRequestHandler<GetActiveHomesQuery, List<HomeModel>>, HomesQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllHomesQuery, List<HomeModel>>, HomesQueryHandler>();

            services.AddControllers();
            services.AddOpenApiDocument(config => {
                config.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Please enter a valid token",
                        Name = "Authorization",
                        Type = OpenApiSecuritySchemeType.ApiKey
                    });
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "HomeSeeker API";
                };
                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            var connectionString = Configuration.GetConnectionString("HomeSeekerDBConnection");
            services.AddDbContext<HomeSeekerDBContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Data")));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}