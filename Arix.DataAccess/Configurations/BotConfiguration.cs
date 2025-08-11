using Arix.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arix.DataAccess.Configurations;

internal class BotConfiguration : IEntityTypeConfiguration<Bot>
{
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.TradingPair)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Leverage)
            .IsRequired();

        builder.Property(b => b.CreatedAt)
            .IsRequired();

        builder.Property(b => b.UpdatedAt)
            .IsRequired();

        builder.Property(b => b.CurrentState)
            .IsRequired();

        builder.HasMany(b => b.TradingMode)
            .WithOne()
            .HasForeignKey("BotId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.TradeEntryCondition)
            .WithOne()
            .HasForeignKey("BotId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.ExitTradeCondition)
            .WithOne()
            .HasForeignKey("BotId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
