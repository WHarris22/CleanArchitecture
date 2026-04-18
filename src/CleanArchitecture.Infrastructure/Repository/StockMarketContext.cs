using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class StockMarketContext : DbContext
    {
        public DbSet<StockQuote> StockQuotes { get; set; } = null!;

        public StockMarketContext(DbContextOptions<StockMarketContext> options)
            : base(options)
        {
        }

        public void EnsureSeedData()
        {
            if (StockQuotes.Any())
                return;

            StockQuotes.AddRange(
                new StockQuote("MSFT", "Microsoft Corporation", 379.25m, 0.82m, DateTime.UtcNow),
                new StockQuote("AAPL", "Apple Inc.", 187.09m, -0.16m, DateTime.UtcNow),
                new StockQuote("GOOGL", "Alphabet Inc.", 171.54m, 0.52m, DateTime.UtcNow)
            );

            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockQuote>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasIndex(x => x.Symbol).IsUnique();
                entity.Property(x => x.Symbol).IsRequired();
                entity.Property(x => x.CompanyName).IsRequired();
                entity.Property(x => x.LastPrice).HasPrecision(18, 2);
                entity.Property(x => x.ChangePercent).HasPrecision(6, 2);
            });
        }
    }
}
