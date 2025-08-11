using Arix.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arix.DataAccess.Configurations;

internal class TradeEntryConditionConfiguration : IEntityTypeConfiguration<TradeEntryCondition>
{
    public void Configure(EntityTypeBuilder<TradeEntryCondition> builder)
    {
        builder.HasKey(e => e.Id);
    }
}
