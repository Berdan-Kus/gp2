using gp2.Data;
using gp2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using gp2.Models;
using gp2.DTOs.TransactionDTOs;

namespace gp2.Repositories.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly FinanceDbContext _context;

        public TransactionRepository(FinanceDbContext context)
        {
            _context = context;
        }


        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
        }

        public async Task DeleteTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Transaction>> FilterTransaction(FilterTransactionDTO dto)
        {
            var query = _context.Transactions.AsQueryable();

            // Tarih aralığı
            if (dto.StartDate.HasValue)
                query = query.Where(t => t.TransactionDate >= dto.StartDate.Value);

            if (dto.EndDate.HasValue)
                query = query.Where(t => t.TransactionDate <= dto.EndDate.Value);

            // Kategori ID
            if (dto.CategoryId.HasValue)
                query = query.Where(t => t.CategoryId == dto.CategoryId.Value);

            // İşlem tipi (income/expense)
            if (Enum.TryParse(typeof(TransactionType), dto.TransactionType, true, out var transactionType))
            {
                query = query.Where(t => t.TransactionType == (TransactionType)transactionType);
            }


            // Minimum ve maksimum tutar
            if (dto.MinAmount.HasValue)
                query = query.Where(t => t.TransactionAmount >= dto.MinAmount.Value);

            if (dto.MaxAmount.HasValue)
                query = query.Where(t => t.TransactionAmount <= dto.MaxAmount.Value);

            // Kategori ismi
            if (!string.IsNullOrWhiteSpace(dto.Category))
            {
                query = query.Include(t => t.Category)
                             .Where(t => t.Category.CategoryName.Contains(dto.Category));
            }

            return await query.ToListAsync();
        }







    }
}
