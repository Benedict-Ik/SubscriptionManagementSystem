using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public enum BillingCycle
    {
        Weekly,
        Monthly,
        Quarterly,
        BiAnnually,
        Annually
    }

    public class Plan
    {
        public Guid PlanId { get; set; }

        [StringLength(70, ErrorMessage = "Name cannot exceed 70 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public BillingCycle BillingCycle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Navigation property for subscriptions referencing this plan.
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }

}
