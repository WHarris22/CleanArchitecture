using CleanArchitecture.Infrastructure.Repository;
using System;

namespace CleanArchitecture.Infrastructure.Extensions
{
    /// <summary>
    /// Initialises the stock market database with seed data.
    /// </summary>
    /// <param name="context">The stock market context.</param>
    public class StockMarketSeeder(StockMarketContext context)
    {
        private readonly StockMarketContext _context = context;

        /// <summary>
        /// Seeds the database with initial stock quote data if it is empty.
        /// This method should be called during application startup to ensure the database is populated.
        /// If the database already contains stock quotes, this method will not modify the existing data.
        /// </summary>
        /// <remarks>
        /// The seed data includes a predefined set of stock quotes for demonstration purposes.
        /// In a production environment, consider implementing a more robust seeding strategy or using migrations.
        /// </remarks>
        /// <returns>Returns void.</returns>
        /// <exception cref="Exception">Throws an exception if seeding fails due to database issues.</exception>
        /// <example>
        /// To use this seeder, call the Seed method during application startup:
        /// <code>
        /// var seeder = new StockMarketSeeder(context);
        /// seeder.Seed();
        /// </code>
        /// </example> 
        public void Seed()
        {
            _context.EnsureSeedData();
        }
    }
}