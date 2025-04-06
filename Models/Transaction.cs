namespace gp2.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; } // PK
        public DateTime TransactionDate { get; set; }

        public int UserId { get; set; } // FK
        public User User { get; set; } // Navigation property

        public int CategoryId { get; set; } // FK
        public Category Category { get; set; } // Navigation property

        public string TransactionDescription { get; set; }

        public enum TransactionType
        {
            income,
            expense
        }


        public int TransactionAmount { get; set; }
    }

}
