using gp2.Models;

namespace gp2.DTOs.TransactionDTOs
{
    public class GetTransactionDTO
{
    public int TransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public int CategoryId { get; set; } // Kategori ID'yi içerecek
    public string CategoryName { get; set; } // Kategori adını içerecek
    public string TransactionDescription { get; set; }
    public string TransactionType { get; set; }
    public int TransactionAmount { get; set; }
}

}
