using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "LEDGERBAL")]
    public class LedgerBalance
    {
        [XmlElement(ElementName = "BALAMT")]
        public string BALAMT { get; set; }

        [XmlElement(ElementName = "DTASOF")]
        public string DTASOF { get; set; }
    }
}
