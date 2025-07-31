namespace RF.Ecom.Core.Features.Orders.Infrastructure;

using Microsoft.EntityFrameworkCore;
using RF.Ecom.Core;
using RF.Ecom.Core.Features.Orders.Entities;

internal sealed class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMark).Assembly);
    }
}