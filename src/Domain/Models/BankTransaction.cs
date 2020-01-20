using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "BANKTRANLIST")]
    public class BankTransaction
    {
        [XmlElement(ElementName = "DTSTART")]
        public string DTSTART { get; set; }
        [XmlElement(ElementName = "DTEND")]
        public string DTEND { get; set; }
        [XmlElement(ElementName = "STMTTRN")]
        public List<TransactionInfo> STMTTRN { get; set; }

    }
}
