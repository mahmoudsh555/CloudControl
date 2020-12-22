
using CloudControl.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudControl.DataContexts
{
    public class CloudContext : DbContext
    {
        public CloudContext()

        {
        }
        public CloudContext(DbContextOptions<CloudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Infrastructure> Infrastructures { get; set; }
        public virtual DbSet<InfrastructureItem> InfrastructureItems { get; set; }
        public virtual DbSet<InfrastructureItemPropertyValue> InfrastructureItemPropertyValues { get; set; }
        public virtual DbSet<ItemTemplate> ItemTemplates { get; set; }
        public virtual DbSet<ItemTemplateProperty> ItemTemplateProperties { get; set; }
        public virtual DbSet<PropertyTemplate> PropertyTemplates { get; set; }
        public virtual DbSet<PropertyTemplateLookup> PropertyTemplateLookups { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        //public virtual DbSet<vwInfrastructure> vwInfrastructures { get; set; }
        //public virtual DbSet<VwTemplate> VwTemplates { get; set; }
        public virtual DbSet<VwInfrastructure> VwInfrastructures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Infrastructures)
                .WithOne(e => e.Company);

            modelBuilder.Entity<Infrastructure>()
                .HasMany(e => e.InfrastructureItems)
                .WithOne(e => e.Infrastructure);

            modelBuilder.Entity<InfrastructureItem>()
                .HasMany(e => e.InfrastructureItemPropertyValues)
                .WithOne(e => e.InfrastructureItem);

            modelBuilder.Entity<ItemTemplate>()
                .HasMany(e => e.InfrastructureItems)
                .WithOne(e => e.ItemTemplate);

            modelBuilder.Entity<ItemTemplate>()
                .HasMany(e => e.ItemTemplateProperties)
                .WithOne(e => e.ItemTemplate);

            modelBuilder.Entity<PropertyTemplate>()
                .HasMany(e => e.InfrastructureItemPropertyValues)
                .WithOne(e => e.PropertyTemplate);

            modelBuilder.Entity<PropertyTemplate>()
                .HasMany(e => e.ItemTemplateProperties)
                .WithOne(e => e.PropertyTemplate);

            modelBuilder.Entity<PropertyTemplate>()
                .HasMany(e => e.PropertyTemplateLookups)
                .WithOne(e => e.PropertyTemplate);

            modelBuilder.Entity<PropertyType>()
                .HasMany(e => e.PropertyTemplates)
                .WithOne(e => e.PropertyType);

            modelBuilder.Entity<VwInfrastructure>()
                .HasNoKey();
        }
    }
}
