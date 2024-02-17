// Importing namespaces for data annotations and database schema attributes
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Define the namespace for the models in the application
namespace ViseVault.Models
{
    // Define the Category class to represent a category entity in the database
    public class Category
    {
        // Define the CategoryId property as the primary key for the Category entity
        [Key]
        public int CategoryId { get; set; }

        // Define the Title property to store the title of the category
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        // Define the Icon property to store the icon associated with the category
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        // Define the Type property to store the type of the category (e.g., Expense or Income)
        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";

        // Define a computed property TitleWithIcon which concatenates the Icon and Title properties
        // This property is not mapped to the database
        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return this.Icon + " " + this.Title;
            }
        }
    }
}
