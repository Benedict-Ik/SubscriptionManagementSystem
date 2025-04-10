using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public class ExternalLogin
    {
        public Guid ExternalLoginId { get; set; }

        [StringLength(100, ErrorMessage = "Provider cannot exceed 100 characters.")]
        public string Provider { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "ProviderKey cannot exceed 100 characters.")]
        public string ProviderKey { get; set; } = string.Empty;

        // Foreign Key
        public Guid UserId { get; set; }

        // Navigation property 
        public User User { get; set; }
    }

}
