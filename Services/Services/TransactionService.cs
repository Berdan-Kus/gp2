using AutoMapper;
using gp2.DTOs.TransactionDTOs;
using gp2.Models;
using gp2.Repositories.Interfaces;
using gp2.Repositories.Repositories;
using gp2.Services.Interfaces;

namespace gp2.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> CreateTransactionAsync(CreateTransactionDTO createTransactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(createTransactionDTO);
            return await _transactionRepository.CreateTransactionAsync(transaction);
        }

        public async Task<IEnumerable<GetTransactionDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            return _mapper.Map<IEnumerable<GetTransactionDTO>>(transactions);
        }

        public async Task<GetTransactionDTO?> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return null;
            }

            return _mapper.Map<GetTransactionDTO>(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(DeleteTransactionDTO deleteTransactionDTO)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(deleteTransactionDTO.TransactionId);
            if (transaction == null)
            {
                return false;
            }

            await _transactionRepository.DeleteTransactionAsync(transaction);
            return true;
        }

        public async Task<bool> UpdateTransactionAsync(UpdateTransactionDTO updateTransactionDTO)
        {
            var existingTransaction = await _transactionRepository.GetTransactionByIdAsync(updateTransactionDTO.TransactionId);
            if (existingTransaction == null)
            {
                return false;
            }

            _mapper.Map(updateTransactionDTO, existingTransaction);
            await _transactionRepository.UpdateTransactionAsync(existingTransaction);
            return true;
        }


        public async Task<List<GetTransactionDTO>> FilterTransaction(FilterTransactionDTO filterTransactionDTO)
        {
            var transaction = await _transactionRepository.FilterTransaction(filterTransactionDTO);
            return _mapper.Map<List<GetTransactionDTO>>(transaction);
        }

        



    }
}
