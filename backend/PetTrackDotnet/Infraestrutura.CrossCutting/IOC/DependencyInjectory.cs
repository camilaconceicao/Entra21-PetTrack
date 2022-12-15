using Aplication.Authentication;
using Aplication.Controllers;
using Aplication.Interfaces;
using Aplication.Utils.HashCripytograph;
using Aplication.Utils.ValidatorDocument;
using Aplication.Validators.Care;
using Aplication.Validators.Ong;
using Aplication.Validators.Pet;
using Aplication.Validators.Usuario;
using Aplication.Validators.Utils;
using Domain.Interfaces;
using Domain.Services;
using Infra.Data.DataBaseContext;
using Infra.Data.Repository.Interface.Base;
using Infra.Data.Repository.Interface.Care;
using Infra.Data.Repository.Interface.Ong;
using Infra.Data.Repository.Interface.Pet;
using Infra.Data.Repository.Interface.Usuario;
using Infra.Data.Repository.ReadRepository;
using Infra.Data.Repository.WriteRepository;
using Infraestrutura.Repository.External;
using Infraestrutura.Repository.Interface.Base;
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
            services.AddTransient<IPetValidator, PetValidator>();
            services.AddTransient<IUsuarioValidator, UsuarioValidator>();
            services.AddTransient<IUtilsValidator,UtilsValidatior>();
            services.AddTransient<IOngValidator,OngValidator>();
            services.AddTransient<ICareValidator,CareValidator>();

            //Aplicação
            services.AddScoped<IPetApp, PetApp>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IAuthApp, AuthApp>();
            services.AddScoped<IUtilsApp, UtilsApp>();
            services.AddScoped<IOngApp, OngApp>();
            services.AddScoped<ICareApp, CareApp>();

            //Domínio
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUtilsService, UtilService>();
            services.AddScoped<IOngService, OngService>();
            services.AddScoped<ICareService, CareService>();

            //Repositorio
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
            services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
            services.AddScoped<IExternalRepository, ExternalRepository>();
            services.AddScoped<IPetReadRepository, PetReadRepository>();
            services.AddScoped<IPetWriteRepository, PetWriteRepository>();
            services.AddScoped<IOngWriteRepository, OngWriteRepository>();
            services.AddScoped<IOngReadRepository, OngReadRepository>();
            services.AddScoped<ICareWriteRepository, CareWriteRepository>();
            services.AddScoped<ICareReadRepository, CareReadRepository>();
            
            //Context
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
        }
    }
}
