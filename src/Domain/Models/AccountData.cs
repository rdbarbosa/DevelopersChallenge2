using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "BANKACCTFROM")]
    public class AccountData
    {
        [XmlElement(ElementName = "BANKID")]
        public string BANKID { get; set; }

        [XmlElement(ElementName = "ACCTID")]
        public string ACCTID { get; set; }

        [XmlElement(ElementName = "ACCTTYPE")]
        public string ACCTTYPE { get; set; }
    }
}
