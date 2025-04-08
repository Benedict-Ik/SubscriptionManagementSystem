namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public enum SubscriptionStatus
    {
        Running,
        Expired,
        Cancelled
    }

    public class Subscription
    {
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public Guid PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NextRenewalDate { get; set; }
        public SubscriptionStatus Status { get; set; }
        //public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties:
        public User User { get; set; }
        public Plan Plan { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

}
