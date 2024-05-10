using Microsoft.Extensions.DependencyInjection;

namespace BsBlazor;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBsBlazorServices(this IServiceCollection services)
    {
        services.AddScoped<IModalService, ModalService>();
        return services;
    }
}
