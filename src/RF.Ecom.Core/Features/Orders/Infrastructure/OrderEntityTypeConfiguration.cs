namespace RF.Ecom.Core.Features.Orders.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Ecom.Core.Features.Orders.Entities;

internal sealed class OrderEntityTypeConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Reference)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.DateCreated)
                .IsRequired();

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.DomainId)
            .HasDatabaseName("IX_Orders_DomainId")
            .IsUnique();

        builder.HasIndex(x => x.Status)
            .HasDatabaseName("IX_Orders_Status");
    }
}
