using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Vander.Wallet.Service.CommandStack;

public static class CommandStackServiceExtensions
{
    public static void AddCommandStackServiceExtensions(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}