using Arix.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arix.DataAccess.Configurations;

internal class FilterConfiguration : IEntityTypeConfiguration<Filter>
{
    public void Configure(EntityTypeBuilder<Filter> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(f => f.Indicator)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(32);

        builder.Property(f => f.IntervalMinutes)
            .IsRequired();

        builder.Property(f => f.ExecutionType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(32);

        builder.Property(f => f.Operator)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(16);
    }
}