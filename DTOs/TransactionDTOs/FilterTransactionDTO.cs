namespace gp2.DTOs.TransactionDTOs
{
    public class FilterTransactionDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CategoryId { get; set; }
        public string? TransactionType { get; set; } // "income" veya "expense"
        public int? MinAmount { get; set; }
        public int? MaxAmount { get; set; }
        public string? Category { get; internal set; }
    }


}
