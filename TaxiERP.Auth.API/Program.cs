using DotNetEnv;
using TaxiERP.Auth.API.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
// Add services to the container.

// Injeção de dependência
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddDatabase(connectionString);
builder.Services.AddRepositories();
builder.Services.AddCustomServices();
builder.Services.AddAuth(builder.Configuration);

var app = builder.Build();

// middlewares
app.UseCustomMiddlewares(app.Environment);

app.MapControllers();

app.Run();
