using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
namespace TaxiERP.Auth.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // swagger apenas em dev
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // middleware de tratamento e segurança
            app.UseMiddleware<TaxiERP.Auth.API.Middlewares.ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();

            //roteamento 
            app.UseRouting();

            // Rate limit
            app.UseRateLimiter();

            // autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();


            return app;
        }
    }
}
