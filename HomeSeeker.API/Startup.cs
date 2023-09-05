using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json.Serialization;

using Data;
using Data.Models;

using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Authorization;
using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands.HomeCommands.AddHome;
using HomeSeeker.API.Commands.HomeCommands.DeleteHome;
using HomeSeeker.API.Commands.HomeCommands.UpdateHome;
using HomeSeeker.API.Commands.UserCommands.RegisterUser;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using HomeSeeker.API.Queries.HomeQueries.GetActiveHomes;
using HomeSeeker.API.Queries.HomeQueries.GetAllHomes;
using HomeSeeker.API.Queries.HomeQueries.GetHomeById;
using HomeSeeker.API.Queries.HomeQueries.GetHomesByUserId;
using HomeSeeker.API.Queries.HomeQueries.GetMaxPrice;
using HomeSeeker.API.Queries.UserQueries.GetUserById;
using HomeSeeker.API.Queries.UserQueries.Authenticate;
using HomeSeeker.API.Queries.UserQueries.GetAllUsers;
using HomeSeeker.API.Repositories;
using HomeSeeker.API.Repositories.HomeRepositories;
using HomeSeeker.API.Repositories.UserRepositories;

using MediatR;

using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using NSwag;
using NSwag.Generation.Processors.Security;

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

            services.AddScoped<IGetHomeRepository, GetHomeRepository>();
            services.AddScoped<IGetRepositoryBase<UserModel>, GetUserRepository>();
            services.AddScoped<IEntityOperationsRepositoryBase<User>, UserOperationsRepository>();
            services.AddScoped<IEntityOperationsRepositoryBase<Home>, HomeOperationsRepository>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<JwtMiddleware>();

            services.AddScoped<IRequestHandler<RegisterUserCommand, OperationResult>, RegisterUserCommandHandler>();

            services.AddScoped<IRequestHandler<GetAllUsersQuery, List<UserModel>>, GetAllUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, UserModel>, GetUserByIdQueryHandler>();
            services.AddScoped<IRequestHandler<AuthenticateQuery, AuthenticateResponse>, AuthenticateQueryHandler>();

            services.AddScoped<IRequestHandler<AddHomeCommand>, AddHomeCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteHomeCommand>, DeleteHomeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateHomeCommand>, UpdateHomeCommandHandler>();

            services.AddScoped<IRequestHandler<GetActiveHomesQuery, List<HomeModel>>, GetActiveHomesQueryHandler>();
            services.AddScoped<IRequestHandler<GetMaxPriceQuery, decimal>, GetMaxPriceQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllHomesQuery, List<HomeModel>>, GetAllHomesQueryHandler>();
            services.AddScoped<IRequestHandler<GetHomeByIdQuery, HomeModel>, GetHomeByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetHomesByUserIdQuery, List<HomeModel>>, GetHomesByUserIdQueryHandler>();

            services.AddControllers();
            services.AddHttpContextAccessor();
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