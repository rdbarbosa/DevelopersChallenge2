using ProjetoNibo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNibo.Services.Interfaces
{
    public interface ITransactionService
    {
        void AddFromFile(OFXFile fileData);

        List<Transaction> GetAll();
    }
}
