using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetoNibo.Domain.Models
{
    [XmlRoot(ElementName = "STATUS")]
    public class Status
    {
        [XmlElement(ElementName = "CODE")]
        public string CODE { get; set; }

        [XmlElement(ElementName = "SEVERITY")]
        public string SEVERITY { get; set; }
    }
}
