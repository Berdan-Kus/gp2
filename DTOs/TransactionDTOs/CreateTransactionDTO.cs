namespace gp2.DTOs.TransactionDTOs
{
    public class CreateTransactionDTO
    {
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; } // "income" veya "expense"
        public int TransactionAmount { get; set; }
    }
}
