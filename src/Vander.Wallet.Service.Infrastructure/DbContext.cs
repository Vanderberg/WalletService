using Microsoft.EntityFrameworkCore;

namespace Vander.Wallet.Service.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Domain.Wallets.Wallet> Accounts { get; set; }
}