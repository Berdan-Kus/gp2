namespace gp2.DTOs.TransactionDTOs
{
    public class UpdateTransactionDTO
    {
        public int TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; } // Nullable, isteğe bağlı değişiklikler için
        public int? CategoryId { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; }
        public int? TransactionAmount { get; set; }
    }
}
