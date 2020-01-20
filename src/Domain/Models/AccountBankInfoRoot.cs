using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "BANKMSGSRSV1")]
    public class AccountBankInfoRoot
    {
        [XmlElement(ElementName = "STMTTRNRS")]
        public AccountRequestInfoRoot STMTTRNRS { get; set; }
    }
}
