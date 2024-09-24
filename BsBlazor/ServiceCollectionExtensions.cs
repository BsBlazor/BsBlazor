using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BsBlazor.Plus")]
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
