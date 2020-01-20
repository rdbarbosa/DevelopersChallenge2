using ProjetoNibo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNibo.Infra.Map
{
    public class TransactionMapper
    {
        public Transaction MapToObject(SqlDataReader reader)
        {
            var transaction = new Transaction
            (
                id: Convert.ToInt32(reader["Id"]),
                type: reader["Type"].ToString(),
                date: Convert.ToDateTime(reader["Date"]),
                amount: float.Parse(reader["Amount"].ToString()),
                description: reader["Description"].ToString()
            );

            return transaction;
        }
    }
}
