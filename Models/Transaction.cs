namespace gp2.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public string? TransactionDescription { get; set; }

        public TransactionType TransactionType { get; set; } // Enum'u property olarak tanımladık.

        public int TransactionAmount { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
