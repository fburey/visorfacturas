using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VisorFacturas.Util
{
    //class clsTC
    //{
    //}
    [XmlRoot(ElementName = "Tc")]
    public class clsTC
    {
        [XmlElement(ElementName = "Fecha")]
        public string Fecha { get; set; }

        [XmlElement(ElementName = "Valor")]
        public string Valor { get; set; }

        [XmlElement(ElementName = "Ano")]
        public string Ano { get; set; }

        [XmlElement(ElementName = "Mes")]
        public string Mes { get; set; }

        [XmlElement(ElementName = "Dia")]
        public string Dia { get; set; }
    }

    [XmlRoot(ElementName = "Detalle_TC")]
    public class clsDetalleTcBcn
    {
        [XmlElement(ElementName = "Tc")]
        public List<clsTC> mlstTasaCambioMes = new List<clsTC>();
    }
}
