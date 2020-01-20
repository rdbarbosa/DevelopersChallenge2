using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "STMTTRNRS")]
    public class AccountRequestInfoRoot
    {
        [XmlElement(ElementName = "TRNUID")]
        public string TRNUID { get; set; }

        [XmlElement(ElementName = "STATUS")]
        public Status STATUS { get; set; }

        [XmlElement(ElementName = "STMTRS")]
        public AccountRequestInfo STMTRS { get; set; }
    }
}
