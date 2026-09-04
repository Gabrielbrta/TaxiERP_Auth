using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using TaxiERP.Auth.Application.Features.Auth.Commands.RegistrarOrganizacao;
using TaxiERP.Auth.Domain.Interfaces;
using TaxiERP.Auth.Infrastructure.Data;
using TaxiERP.Auth.Infrastructure.Repositories;
using MediatR;
using TaxiERP.Auth.Application.Common.Behaviors;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
// Add services to the container.

//MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegistrarOrganizacaoCommand).Assembly);

    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});


// FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(RegistrarOrganizacaoCommand).Assembly);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
