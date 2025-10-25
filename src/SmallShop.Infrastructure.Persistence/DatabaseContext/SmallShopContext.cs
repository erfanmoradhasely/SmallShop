
using Microsoft.EntityFrameworkCore;
using SmallShop.Domain.Common;
using SmallShop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmallShop.Infrastructure.Persistence.DatabaseContext;
public class SmallShopContext : DbContext
{
    public SmallShopContext(DbContextOptions<SmallShopContext> options) : base(options)
    {
    }


    public DbSet<Product> Products { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var modifiedEntities = GetModifiedEntities();
        await PublishEvents(modifiedEntities);
        return await base.SaveChangesAsync(cancellationToken);
    }
    private List<AggregateRoot> GetModifiedEntities() =>
        ChangeTracker.Entries<AggregateRoot>()
            .Where(x => x.State != EntityState.Detached)
            .Select(c => c.Entity)
            .Where(c => c.DomainEvents.Any()).ToList();

    private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
    {
        foreach (var entity in modifiedEntities)
        {
            var events = entity.DomainEvents;
            foreach (var domainEvent in events)
            {

            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmallShopContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}