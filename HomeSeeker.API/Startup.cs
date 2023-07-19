using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IRequestHandler<RegisterUser>, UsersCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllUsersQuery, List<UserModel>>, UsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserByIdQuery, UserModel>, UsersQueryHandler>();
            services.AddScoped<IRequestHandler<AuthenticateQuery, AuthenticateResponse>, UsersQueryHandler>();

            services.AddControllers();
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
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

                app.UseSwagger();
                app.UseSwaggerUI();
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