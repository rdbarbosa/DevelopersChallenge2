using ProjetoNibo.Domain.Models;
using ProjetoNibo.Infra.Interface;
using ProjetoNibo.Services.Interfaces;
using System.Collections.Generic;

namespace ProjetoNibo.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionsContext _transactionsContext { get; set; }

        public TransactionService(ITransactionsContext transactionsContext)
        {
            _transactionsContext = transactionsContext;
        }

        public void AddFromFile(OFXFile fileData)
        {
            var transactionList = new List<Transaction>();

            foreach (var transaction in fileData.BANKMSGSRSV1.STMTTRNRS.STMTRS.BANKTRANLIST.STMTTRN)
            {
                transactionList.Add(new Transaction(transaction));
            }

            _transactionsContext.Insert(transactionList);

        }

        public List<Transaction> GetAll()
        {
            var transactions = _transactionsContext.GetAll();

            return transactions;

        }
    }
}
