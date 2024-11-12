using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class view_rpt_BANCOS
    {
        public DateTime fecha { get; set; }
        public String nodoc { get; set; }
        public String numcom { get; set; }
        public String Beneficiario { get; set; }
        public String Concepto01 { get; set; }
        public String Concepto02 { get; set; }
        public Decimal tasaC { get; set; }
        public Decimal valche { get; set; }
        public Decimal MTO_C { get; set; }
        public Decimal MTO_D { get; set; }
        public String tmoneda { get; set; }
        public String aplicado { get; set; }
        public String cuenco { get; set; }
        public String Banco { get; set; }


    }
}
