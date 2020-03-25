using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class view_rpt_facturasmes
    {
        public string fac_numfac { get; set; }
        public DateTime fac_fecha { get; set; }
        public string cli_nombre { get; set; }
        public string cli_pais { get; set; }
        public string cli_ciudad { get; set; }
        public double rem_cant { get; set; }
        public double rem_precio { get; set; }
        public double rem_cantprecio { get; set; }
        public double rem_descuen { get; set; }
        public double rem_tramit { get; set; }
        public double pag_amount { get; set; }
        public string pag_numroc { get; set; }
        public DateTime? pag_fecha { get; set; }
        public double fac_total { get; set; }
        public string tipo_regimen { get; set; }

    }
}
