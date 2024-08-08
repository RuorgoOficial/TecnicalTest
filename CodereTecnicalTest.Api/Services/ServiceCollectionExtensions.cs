using CodereTecnicalTest.Application.Extensions;
using CodereTecnicalTest.Application.Services;
using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using CodereTecnicalTest.Domain.Entities;
using CodereTecnicalTest.Infrastructure.Access;
using CodereTecnicalTest.Infrastructure.Context;
using CodereTecnicalTest.Infrastructure.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CodereTecnicalTest.Api.Services
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
             this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, CodereTecnicalTestUnitOfWork>();

            services.AddScoped<IRepository<Show>, CodereTecnicalTestRepository<Show>>();
            services.AddScoped<IRepository<Genre>, CodereTecnicalTestRepository<Genre>>();
            services.AddScoped<IRepository<Network>, CodereTecnicalTestRepository<Network>>();
            services.AddScoped<IRepository<Country>, CodereTecnicalTestRepository<Country>>();
            services.AddScoped<IRepository<Schedule>, CodereTecnicalTestRepository<Schedule>>();
            services.AddScoped<IRepository<Rating>, CodereTecnicalTestRepository<Rating>>();
            services.AddScoped<IRepository<Externals>, CodereTecnicalTestRepository<Externals>>();
            services.AddScoped<IRepository<Image>, CodereTecnicalTestRepository<Image>>();
            services.AddScoped<IRepository<Links>, CodereTecnicalTestRepository<Links>>();

            return services;
        }
        public static IServiceCollection AddDatabaseContext(
             this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CodereTecnicalTestDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CodereTecnicalTestContext")));
            services.AddDbContext<CodereTecnicalTestDBContext>(opt => opt.UseInMemoryDatabase(configuration.GetConnectionString("CodereTecnicalTestContext")!));

            return services;
        }
        public static IServiceCollection AddMediatRAssemblies(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(VersionExtensions).Assembly);
            });
            services.AddSingleton<IVersionService, VersionService>();

            return services;
        }

        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpRepository<ShowDTO>, ShowHttpRepository>();
            services.AddHttpClient<IHttpRepository<ShowDTO>, ShowHttpRepository>(u =>
                u.BaseAddress = new Uri(configuration["ServiceUrls:TvmazeApi"]!)
            );

            return services;
        }
    }
}
