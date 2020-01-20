using Microsoft.AspNetCore.Mvc;
using ProjetoNibo.Domain.Models;
using ProjetoNibo.Infra.Repository;
using ProjetoNibo.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoNibo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transaction;

        public TransactionsController(ITransactionService transaction)
        {
            _transaction = transaction;
        }

        [HttpGet("all")]
        public List<Transaction> GetTransactions()
        {
            return _transaction.GetAll();
        }
    }
}