// Import necessary namespaces
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ViseVault.Models; // Import the Category model namespace

// Define the namespace for the models in the application
namespace ViseVault.Models
{
    // Define the Transaction class to represent a financial transaction
    public class Transaction
    {
        // Define the primary key for the Transaction entity
        [Key]
        public int TransactionId { get; set; }

        // Define the foreign key for the related Category entity
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        // Define the navigation property to represent the related Category entity
        public Category? Category { get; set; }

        // Define the amount of the transaction
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public decimal Amount { get; set; } // Change data type to decimal for better precision

        // Define a note for the transaction
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        // Define the date of the transaction
        public DateTime Date { get; set; } = DateTime.Now;

        // Define a property to get the category title with icon
        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        // Define a property to get the formatted amount with currency symbol
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }
    }
}
