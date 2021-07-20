using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class view_rpt_saldoclientes
    {
        public string fac_numfac { get; set; }
        public DateTime fac_fecha { get; set; }
        public String cli_nombre { get; set; }
        public String cli_cod { get; set; }
        public String tipo_regimen { get; set; }
        public decimal factotd { get; set; }
        public decimal factotc { get; set; }
        public String pag_numroc { get; set; }
        public String pag_fecha { get; set; }
        public decimal pag_totd { get; set; }
        public decimal pag_totc { get; set; }
        public decimal sdototd { get; set; }
        public decimal sdototc { get; set; }
        public decimal sdototccalc { get; set; }
        public decimal sdo_30 { get; set; }
        public decimal sdo_60 { get; set; }
        public decimal sdo_90 { get; set; }
        public decimal sdo_mas90 { get; set; }
        public int dias { get; set; }
        public decimal sdo_antd { get; set; }
        public decimal sdo_actd { get; set; }
        public decimal sdo_actccalc { get; set; }
        public String concept { get; set; }
        public Int16 fac_debe { get; set; }
    }
}
