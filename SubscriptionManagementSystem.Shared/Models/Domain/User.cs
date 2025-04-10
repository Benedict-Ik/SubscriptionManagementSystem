using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public class User
    {
        public Guid UserId { get; set; }

        [StringLength(30, ErrorMessage = "Username cannot exceed 30 characters.")]
        public string Username { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Password must be between 8 to 50 characters long.")]
        public string Password { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        [StringLength(70, ErrorMessage = "First Name cannot exceed 70 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(70, ErrorMessage = "Last Name cannot exceed 70 characters.")]
        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }


        // Navigation properties (N-M)- collections are initialized inline to avoid null references.
        public ICollection<ExternalLogin> ExternalLogins { get; set; } = new List<ExternalLogin>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
