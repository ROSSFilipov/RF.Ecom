namespace RF.Ecom.Core.Features.Orders.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Ecom.Core.Features.Orders.Entities;

internal sealed class ItemEntityTypeConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.DateCreated)
            .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.DomainId)
            .HasDatabaseName("IX_Items_DomainId")
            .IsUnique();
    }
}
