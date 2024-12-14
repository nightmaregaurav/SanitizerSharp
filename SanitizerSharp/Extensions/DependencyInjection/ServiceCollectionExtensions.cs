using Microsoft.Extensions.DependencyInjection;

namespace SanitizerSharp.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSanitizer<TFor, TSanitizer>(this IServiceCollection services) where TSanitizer : class, ISanitizer<TFor>
    {
        return services.AddTransient<ISanitizer<TFor>, TSanitizer>();
    }
}