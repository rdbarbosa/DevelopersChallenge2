using ProjetoNibo.Domain.Models;
using ProjetoNibo.Infra.Interface;
using ProjetoNibo.Infra.Map;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoNibo.Infra.Context
{
    public class TransactionsContext : ITransactionsContext
    {
        private string ConnectionString { get; set; }
        private TransactionMapper TransactionMapper { get; set; }

        public TransactionsContext(string connectionString)
        {
            ConnectionString = connectionString;
            TransactionMapper = new TransactionMapper();
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public List<Transaction> GetAll()
        {
            var list = new List<Transaction>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Transactions", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(TransactionMapper.MapToObject(reader));
                    }
                }
                conn.Close();
            }
            return list;
        }

        public void Insert(List<Transaction> transactions)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into Transactions (type, date, amount, description) values(@Type, @Date, @Amount, @Description)", conn);

                using (cmd)
                {
                    foreach (var transaction in transactions)
                    {
                        cmd.Parameters.AddWithValue("@Type", transaction.Type);
                        cmd.Parameters.AddWithValue("@Date", transaction.Date);
                        cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                        cmd.Parameters.AddWithValue("@Description", transaction.Description);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("Duplicate entry"))
                            {
                                cmd.Parameters.Clear();
                                continue;
                            }

                            throw (ex);
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}
