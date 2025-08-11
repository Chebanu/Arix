using Arix.Contracts.Models;
using Arix.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Arix.DataAccess;

public class ArixDbContext : DbContext
{
    public virtual DbSet<Filter> Bots { get; set; }
    public virtual DbSet<Filter> Filters { get; set; }
    public virtual DbSet<TradingMode> TradingModes { get; set; }
    public virtual DbSet<TradeEntryCondition> TradeEntryConditions { get; set; }
    public virtual DbSet<ExitTradeCondition> ExitTradeConditions { get; set; }


    public ArixDbContext(DbContextOptions<ArixDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BotConfiguration().Configure(modelBuilder.Entity<Bot>());
        new TradingModeConfiguration().Configure(modelBuilder.Entity<TradingMode>());
        new FilterConfiguration().Configure(modelBuilder.Entity<Filter>());
        new TradeEntryConditionConfiguration().Configure(modelBuilder.Entity<TradeEntryCondition>());
        new ExitTradeConditionConfiguration().Configure(modelBuilder.Entity<ExitTradeCondition>());
    }
}