using Microsoft.Extensions.DependencyInjection;

namespace BsBlazor;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBsBlazorServices(this IServiceCollection services)
    {
        services.AddScoped<IModalService, ModalService>();
        services.AddScoped<IToastService, ToastService>();
        return services;
    }
}
