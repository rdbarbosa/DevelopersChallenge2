using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "STMTRS")]
    public class AccountRequestInfo
    {
        [XmlElement(ElementName = "CURDEF")]
        public string CURDEF { get; set; }

        [XmlElement(ElementName = "BANKACCTFROM")]
        public AccountData BANKACCTFROM { get; set; }

        [XmlElement(ElementName = "BANKTRANLIST")]
        public BankTransaction BANKTRANLIST { get; set; }

        [XmlElement(ElementName = "LEDGERBAL")]
        public LedgerBalance LEDGERBAL { get; set; }

    }
}
