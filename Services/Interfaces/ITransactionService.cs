using gp2.DTOs.TransactionDTOs;
using gp2.Models;

namespace gp2.Services.Interfaces
{
    public interface ITransactionService
    {

        Task<Transaction> CreateTransactionAsync(CreateTransactionDTO createTransactionDTO);

        Task<IEnumerable<GetTransactionDTO>> GetAllTransactionsAsync();

        Task<GetTransactionDTO?> GetTransactionByIdAsync(int id);

        Task<bool> DeleteTransactionAsync(DeleteTransactionDTO deleteTransactionDTO);

        Task<bool> UpdateTransactionAsync(UpdateTransactionDTO updateTransactionDTO);

        Task<List<GetTransactionDTO>> FilterTransaction(FilterTransactionDTO filterTransactionDTO);
    }
}
