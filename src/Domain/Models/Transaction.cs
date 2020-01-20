using System;
using System.Globalization;

namespace ProjetoNibo.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public Transaction(TransactionInfo transactionInfo)
        {
            Type = transactionInfo.TRNTYPE;
            Date = DateTime.ParseExact(transactionInfo.DTPOSTED.Substring(0, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Amount = double.Parse(transactionInfo.TRNAMT);
            Description = transactionInfo.MEMO;
        }

        public Transaction(int id, string type, DateTime date, double amount, string description)
        {
            Id = id;
            Date = date;
            Type = type;
            Amount = amount;
            Description = description;
        }
    }
}
