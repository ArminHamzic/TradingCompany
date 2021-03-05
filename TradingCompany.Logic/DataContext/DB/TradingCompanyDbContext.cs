using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompany.Contracts;
using TradingCompany.Logic.Entities;
using TradingCompany.Logic.Entities.Persistence;

namespace TradingCompany.Logic.DataContext.DB
{
    class TradingCompanyDbContext : DbContext, IContext
    {
        static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=TradingCompanyDb;Integrated Security=True";

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productBuilder = modelBuilder.Entity<Product>();

            productBuilder
                .ToTable(nameof(Product))
                .HasKey(p => p.Id);

            productBuilder
                .HasIndex(p => p.Number)
                .IsUnique();

            productBuilder
                .Property(p => p.Number)
                .HasMaxLength(8)
                .IsRequired();

            productBuilder
                .Property(p => p.Name)
                .HasMaxLength(256)
                .IsRequired();

            productBuilder
                .Property(p => p.Price)
                .IsRequired();

            var customerBuilder = modelBuilder.Entity<Customer>();

            customerBuilder
                .ToTable(nameof(Customer))
                .HasKey(p => p.Id);

            customerBuilder
                .Property(p => p.Number)
                .HasMaxLength(8)
                .IsRequired();

            customerBuilder
                .Property(p => p.Name)
                .HasMaxLength(256)
                .IsRequired();

            var conditionBuilder = modelBuilder.Entity<Condition>();

            conditionBuilder
                .ToTable(nameof(Condition))
                .HasKey(p => p.Id);

            conditionBuilder
                .Property(p => p.ProductId)
                .IsRequired();

            conditionBuilder
                .Property(p => p.CustomerId)
                .IsRequired();

            conditionBuilder
                .Property(p => p.ConditionType)
                .IsRequired();

            conditionBuilder
                .Property(p => p.Value)
                .IsRequired();

            conditionBuilder
                .Property(p => p.Quantity)
                .IsRequired();

            conditionBuilder
                .Property(p => p.Note)
                .IsRequired();

            var orderBuilder = modelBuilder.Entity<Order>();

            orderBuilder
                .ToTable(nameof(Order))
                .HasKey(p => p.Id);

            orderBuilder
                .Property(p => p.CustomerId)
                .IsRequired();

            orderBuilder
                .Property(p => p.ProductId)
                .IsRequired();

            orderBuilder
                .Property(p => p.Count)
                .IsRequired();

            orderBuilder
                .Property(p => p.Discount)
                .IsRequired();

            orderBuilder
                .Property(p => p.NetPrice)
                .IsRequired();
        }

        public Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Set<E>().CountAsync();
        }
        public Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() => new E());
        }

        public Task<E> InsertAsync<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() =>
            {
                Set<E>().Add(entity);
                return entity;
            });
        }
        public Task<E> UpdateAsync<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() =>
            {
                Set<E>().Update(entity);
                return entity;
            });
        }
        public Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Task.Run(() =>
            {
                E result = Set<E>().SingleOrDefault(i => i.Id == id);

                if (result != null)
                {
                    Set<E>().Remove(result);
                }
                return result;
            });
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }
    }
}
