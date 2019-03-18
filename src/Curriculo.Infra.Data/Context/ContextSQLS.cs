using Curriculo.Domain.Core.Models;
using Curriculo.Domain.Models;
using Curriculo.Infra.Data.EntityMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Curriculo.Infra.Data.Context
{
    public class ContextSQLS : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public ContextSQLS()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string))
            .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
            .ToList()
            .ForEach(pb => { pb.HasColumnType("varchar(300)"); pb.HasMaxLength(300); });
        }

        public override int SaveChanges()
        {
            var adds = this.ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Added).ToList();
            var updates = this.ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Modified).ToList();
            var deletes = this.ChangeTracker.Entries().Where(e => e.Entity is Entity && e.State == EntityState.Deleted).ToList();
            if (adds.Any()) AddEntities(adds);
            if (updates.Any()) UpdateEntities(updates);
            if (deletes.Any()) DeleteEntities(deletes);
            return base.SaveChanges();
        }

        private void AddEntities(List<EntityEntry> adds)
        {
            adds.ForEach(a =>
            {
                var entity = (Entity)a.Entity;
                entity.CreateAt = DateTime.Now;
            });
        }

        private void UpdateEntities(List<EntityEntry> updates)
        {
            updates.ForEach(a =>
            {
                var entity = (Entity)a.Entity;
                entity.UpdateAt = DateTime.Now;
            });
        }

        private void DeleteEntities(List<EntityEntry> deletes)
        {
            deletes.ForEach(a =>
            {
                var entity = (Entity)a.Entity;
                entity.DeleteAt = DateTime.Now;
                entity.IsDeleted = true;

                a.State = EntityState.Modified;
            });
        }
    }
}
