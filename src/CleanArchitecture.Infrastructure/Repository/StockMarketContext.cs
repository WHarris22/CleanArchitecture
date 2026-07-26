using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Repository
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the stock market application, 
    /// providing access to the StockQuotes DbSet and configuring the entity model. This context 
    /// is responsible for managing the connection to the database, tracking changes to entities,
    /// and ensuring that the database schema is properly configured for the StockQuote entity. 
    /// It also includes a method to seed initial data into the database if it is empty, allowing
    /// for a pre-populated set of stock quotes for testing and demonstration purposes.
    /// </summary>
    public class StockMarketContext : DbContext
    {
        /// <summary>
        /// Gets or sets the stock quotes in the database.
        /// </summary>
        public DbSet<StockQuote> StockQuotes { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockMarketContext"/> class with the 
        /// specified options.
        /// </summary>
        /// <param name="options">The options for the context.</param>
        public StockMarketContext(DbContextOptions<StockMarketContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Ensures that the stock market database is seeded with initial data if it is empty.
        /// This method checks if there are any existing stock quotes in the database, and if not, 
        /// it adds a predefined set of stock quotes for demonstration purposes. It then saves the 
        /// changes to the database. This method should be called during application startup to 
        /// ensure that the database is populated with initial data. If the database already 
        /// contains stock quotes, this method will not modify the existing data.
        /// </summary>
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

        /// <summary>
        /// Configures the entity model for the stock market context, including the StockQuote entity
        ///  and its properties.   
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
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
