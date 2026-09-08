using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;
using TaxiERP.Auth.Application.Common.Behaviors;
using TaxiERP.Auth.Application.Features.Auth.Commands.Login;
using TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao;
using TaxiERP.Auth.Application.Interfaces;
using TaxiERP.Auth.Domain.Interfaces;
using TaxiERP.Auth.Infrastructure.Data;
using TaxiERP.Auth.Infrastructure.Repositories;
using TaxiERP.Auth.Infrastructure.Services;

namespace TaxiERP.Auth.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        // repositories
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        // application services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(RegistrarOrganizacaoCommand).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            // FluentValidation
            services.AddValidatorsFromAssembly(typeof(RegistrarOrganizacaoCommand).Assembly);
            services.AddValidatorsFromAssembly(typeof(LoginCommand).Assembly);

            return services;
        }
        // services
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

        // token jwt
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration) 
        {
            var chaveSecreta = configuration["JWT_SECRET"];
            var key = Encoding.ASCII.GetBytes(chaveSecreta);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // mudar em produção
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization();
            return services;
        }

        public static IServiceCollection AddRateLimitingConfig(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("LoginLimit", opt =>
                {
                    opt.PermitLimit = 5;
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    opt.QueueLimit = 0;
                });

                options.OnRejected = async (context, cancellationToken) =>
                {
                    context.HttpContext.Response.StatusCode = 429;
                    context.HttpContext.Response.ContentType = "application/json";
                    var resposta = new { erro = "Muitas tentativas de login. Aguarde 1 minuto." };
                    await context.HttpContext.Response.WriteAsJsonAsync(resposta, cancellationToken);
                };
            });
            return services;
        }
    }
}
