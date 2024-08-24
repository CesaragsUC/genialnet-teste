using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<GenialnetDbContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddRepositories();

    }

    private static void AddRepositories(this IServiceCollection services)
    {
             services
            .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<ISupplierRespository, SupplierRespository>()
            .AddScoped<IProductRespository, ProductRepository>();

    }
}
