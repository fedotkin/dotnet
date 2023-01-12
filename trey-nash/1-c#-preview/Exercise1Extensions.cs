using Fedotkin.Dotnet.TreyNash.ConsoleServices.Implementations;
using Fedotkin.Dotnet.TreyNash.ConsoleServices.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using static Fedotkin.Dotnet.TreyNash.Ch1_CSharpPreview.Exercise1;

namespace Microsoft.Extensions.DependencyInjection;

public static class Exercise1Extensions
{
    public static IServiceCollection AddExercise1Services(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException("services");

        services.TryAddScoped<IConsoleService, DefaultConsoleService>();
        return services.AddScoped<ITextCompression, TextCompression>();
    }
}
