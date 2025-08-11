using Arix.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arix.DataAccess.Configurations;

internal class TradingModeConfiguration : IEntityTypeConfiguration<TradingMode>
{
    public void Configure(EntityTypeBuilder<TradingMode> builder)
    {

        builder.HasKey(t => t.Id);

        builder.Property(t => t.GridOrdersCount)
            .IsRequired();

        builder.Property(t => t.LogarithmicPriceDistribution)
            .IsRequired();

        builder.Property(t => t.PartialAmountOfGridOrders)
            .IsRequired();

        builder.Property(t => t.StopBotAfterDealsCompleted)
            .IsRequired();

        builder.Property(t => t.AmountAfterToStop)
            .IsRequired(false);

        builder.Property(t => t.IncludeExchangePositionInTrade)
            .IsRequired();
    }
}
