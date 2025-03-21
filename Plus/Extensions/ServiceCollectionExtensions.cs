#if NET9_0_OR_GREATER
using Microsoft.Extensions.DependencyInjection;
namespace BsBlazor.Plus;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBsBlazorPlusOptions(this IServiceCollection services, Action<BsBlazorPlusOptions> setupOptions)
    {
        var options = new BsBlazorPlusOptions();
        setupOptions(options);
        services.AddSingleton(options);
        return services;
    }
}
#endif