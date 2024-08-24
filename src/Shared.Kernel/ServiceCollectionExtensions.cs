using Microsoft.Extensions.DependencyInjection;
using Shared.Kernel.Abstractions;

namespace Shared.Kernel;

public static class ServiceCollectionExtensions
{
    public static void AddSharedConfig(this IServiceCollection services)
    {
        services.AddScoped(typeof(IResult<>), typeof(Result<>));

    }
}
