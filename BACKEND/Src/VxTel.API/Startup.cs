using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VxTel.API.Configs;
using VxTel.API.Services;
using VxTel.Application.PlanosContext;
using VxTel.Application.PlanosContext.Administrador;
using VxTel.Application.PlanosContext.CalculoPlanos;
using VxTel.Domain.Interfaces.Application;
using VxTel.Domain.Interfaces.Repository;
using VxTel.Infra.DataContext;
using VxTel.Infra.Repository;

namespace VxTel.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(environment.ContentRootPath)
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile($"appsettings{environment.EnvironmentName}.json", optional: true)
                  .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            var key = new KeySecret();
            services.Configure<KeySecret>(Configuration.GetSection("KeySecret"));
            Configuration.GetSection("KeySecret").Bind(key);

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new OpenApiInfo
                { Title = "API VXTEL", Description = "API para consultar planos oferecidos pela VXTEL", Version = "V1" });

                x.AddSecurityDefinition("Bearer ", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor se autenticar",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer "
                        }
                       },
                       new string[] { }
                    }
                });
            });

            var autenticacao = Encoding.ASCII.GetBytes(key.Key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(autenticacao),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<ITabelacaoPrecos, TabelacaoPrecos>();
            services.AddScoped<IPlanosVxTelRepository, PlanosVxTelRepository>();
            services.AddScoped<SqlDataContext, SqlDataContext>();
            services.AddScoped<ICalculaPlano, CalculaPlano>();
            services.AddScoped<TokenService, TokenService>();
            services.AddScoped<ILoginUser, LoginUser>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IPlanosVxTellApplication, PlanosVxTellApplication>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Web API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
