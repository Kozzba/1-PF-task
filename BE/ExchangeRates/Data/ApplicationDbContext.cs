using ExchangeRates.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRates.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ExchangeRate> ExchangeRateSet { get; set; }
}
