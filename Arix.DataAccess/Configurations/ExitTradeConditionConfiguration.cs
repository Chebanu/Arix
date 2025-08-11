using Arix.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arix.DataAccess.Configurations;

internal class ExitTradeConditionConfiguration : IEntityTypeConfiguration<ExitTradeCondition>
{
    public void Configure(EntityTypeBuilder<ExitTradeCondition> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.TakeProfitBySignal)
            .IsRequired();

        builder.Property(e => e.EnableStopLoss)
            .IsRequired();

        builder.Property(e => e.TerminateBotAfterStopLossExecution)
            .IsRequired(false);
    }
}