using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "STMTTRN")]
    public class TransactionInfo
    {
        [XmlElement(ElementName = "TRNTYPE")]
        public string TRNTYPE { get; set; }

        [XmlElement(ElementName = "DTPOSTED")]
        public string DTPOSTED { get; set; }

        [XmlElement(ElementName = "TRNAMT")]
        public string TRNAMT { get; set; }

        [XmlElement(ElementName = "FITID")]
        public string FITID { get; set; }

        [XmlElement(ElementName = "CHECKNUM")]
        public string CHECKNUM { get; set; }

        [XmlElement(ElementName = "MEMO")]
        public string MEMO { get; set; }
    }
}
