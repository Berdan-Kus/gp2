namespace gp2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
