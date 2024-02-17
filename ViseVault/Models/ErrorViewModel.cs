// Define the namespace for the models in the application
namespace ViseVault.Models
{
    // Define the ErrorViewModel class to represent error information in the application
    public class ErrorViewModel
    {
        // Define the RequestId property to store the ID of the request associated with the error
        public string? RequestId { get; set; }

        // Define the ShowRequestId property to determine if the RequestId is present and not empty
        // This property is used to decide whether to show the RequestId in the error view
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
