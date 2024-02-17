// Import the Entity Framework Core namespace to access DbContext class
using Microsoft.EntityFrameworkCore;

// Define the namespace for the models in the application
namespace ViseVault.Models
{
    // Define the ApplicationDbContext class, which inherits from DbContext
    public class ApplicationDbContext : DbContext
    {
        // Define the constructor for ApplicationDbContext, which takes DbContextOptions as a parameter
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            // Constructor body left empty
        }

        // Define a property Transactions of type DbSet<Transaction> to represent the Transactions table in the database
        public DbSet<Transaction> Transactions { get; set; }

        // Define a property Categories of type DbSet<Category> to represent the Categories table in the database
        public DbSet<Category> Categories { get; set; }
    }
}
