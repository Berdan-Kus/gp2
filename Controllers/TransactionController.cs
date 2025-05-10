using gp2.DTOs.TransactionDTOs;
using gp2.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gp2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateTransactionAsync([FromBody] CreateTransactionDTO createTransactionDTO)
        {
            var transaction = await _transactionService.CreateTransactionAsync(createTransactionDTO);
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTransactionDTO>>> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTransactionDTO>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound("İşlem bulunamadı.");
            }

            return Ok(transaction);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction([FromBody] DeleteTransactionDTO deleteTransactionDTO)
        {
            var result = await _transactionService.DeleteTransactionAsync(deleteTransactionDTO);
            if (!result)
            {
                return NotFound("İşlem bulunamadı.");
            }

            return Ok("İşlem başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction([FromBody] UpdateTransactionDTO updateTransactionDTO)
        {
            var result = await _transactionService.UpdateTransactionAsync(updateTransactionDTO);
            if (!result)
            {
                return NotFound("İşlem bulunamadı.");
            }

            return Ok("İşlem başarıyla güncellendi.");
        }


        [HttpGet]
        public async Task<IActionResult> FilterTransaction(FilterTransactionDTO filterTransactionDTO) 
        {
            var result = await _transactionService.FilterTransaction(filterTransactionDTO);
            return Ok(result);
        }




    }
}
