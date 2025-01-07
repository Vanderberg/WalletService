using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vander.Wallet.Service.Infrastructure;

public static class InfrastructureExtensions
{
   public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
   {
       services.AddDbContext<AppDbContext>(options =>
           options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));
   }
}