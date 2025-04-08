using System.ComponentModel.DataAnnotations;

namespace SubscriptionManagementSystem.Shared.Models.Domain
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        ElectronicTransfer
    }

    public class Payment
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        // Navigation properties:
        public User User { get; set; }
        public Subscription Subscription { get; set; }
    }
}
