using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "OFX")]
    public class OFXFile
    {
        [XmlElement(ElementName = "BANKMSGSRSV1")]
        public AccountBankInfoRoot BANKMSGSRSV1 { get; set; }
    }
}
