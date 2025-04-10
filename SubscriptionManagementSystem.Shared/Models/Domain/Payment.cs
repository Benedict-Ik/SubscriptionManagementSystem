using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Range(0, double.MaxValue, ErrorMessage = "Amount cannot be negative")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; }

        [Required]
        [StringLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        // Foreign Keys
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Subscription")]
        public Guid SubscriptionId { get; set; }

        // Navigation properties:
        public User User { get; set; }
        public Subscription Subscription { get; set; }
    }
}
