using ProjetoNibo.Domain.Models;
using System.Collections.Generic;

namespace ProjetoNibo.Infra.Interface
{
    public interface ITransactionsContext
    {
        List<Transaction> GetAll();

        void Insert(List<Transaction> transactions);
    }
}
