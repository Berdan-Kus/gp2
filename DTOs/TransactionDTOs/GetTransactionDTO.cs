using gp2.Models;

namespace gp2.DTOs.TransactionDTOs
{
    public class GetTransactionDTO
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CategoryId { get; set; } 
        public Category Category { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
    }
}
