using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Vander.Wallet.Service.Application.QueryStack;

public static class QueryStackServiceExtensions
{
    public static void AddQueryStackServiceExtensions(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}