using Aplication.Authentication;
using Aplication.Controllers;
using Aplication.Interfaces;
using Aplication.Utils.HashCripytograph;
using Aplication.Utils.ValidatorDocument;
using Aplication.Validators.Usuario;
using Aplication.Validators.Utils;
using Domain.Interfaces;
using Domain.Services;
using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.External;
using Infraestrutura.Repository.Interface.Base;
using Infraestrutura.Repository.Interface.Usuario;
using Infraestrutura.Repository.ReadRepository;
using Infraestrutura.Repository.WriteRepository;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.IOC
{
    public static class DependencyInjectory
    {
        public static void Injectory(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //Utils
            services.AddTransient<IHashCriptograph, HashCripytograph>();
            services.AddTransient<IValidatorDocument, ValidatorDocument>();
            services.AddTransient<IJwtTokenAuthentication, JwtAuthentication>();
            services.AddSingleton<IConfiguration>(builder.Configuration);

            //Validators
            services.AddTransient<IUsuarioValidator, UsuarioValidator>();
            services.AddTransient<IUtilsValidator,UtilsValidatior>();

            //Aplicação
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IAuthApp, AuthApp>();
            services.AddScoped<IUtilsApp, UtilsApp>();

            //Domínio
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUtilsService, UtilService>();

            //Repositorio
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
            services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
            services.AddScoped<IExternalRepository, ExternalRepository>();

            //Context
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
        }
    }
}
