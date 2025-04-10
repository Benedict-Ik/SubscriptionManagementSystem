namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsSent { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key
        public Guid UserId { get; set; }

        // Navigation property:
        public User User { get; set; }
    }

}
