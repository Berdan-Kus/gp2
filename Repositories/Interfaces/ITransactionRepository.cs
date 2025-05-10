using gp2.DTOs.TransactionDTOs;
using gp2.Models;

namespace gp2.Repositories.Interfaces
{
    public interface ITransactionRepository
    {

        Task<Transaction> CreateTransactionAsync(Transaction transaction);


        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task<Transaction?> GetTransactionByIdAsync(int id);

        Task DeleteTransactionAsync(Transaction transaction);

        Task UpdateTransactionAsync(Transaction transaction);

        Task<List<Transaction>> FilterTransaction(FilterTransactionDTO dto);




    }
}
