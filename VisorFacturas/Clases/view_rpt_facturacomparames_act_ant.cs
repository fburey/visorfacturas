using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class view_rpt_facturacomparames_act_ant
    {
        public string cli_cod { get; set; }
        public string cli_nombre { get; set; }
        public short fac_mesfact { get; set; }
        public short fac_yearfact { get; set; }
        public double rem_cant_ANT { get; set; }
        public double rem_cantprecio_ANT { get; set; }
        public double rem_descuen_ANT { get; set; }
        public double rem_tramit_ANT { get; set; }
        public double fac_total_ANT { get; set; }
        public double rem_cant_ACT { get; set; }
        public double rem_cantprecio_ACT { get; set; }
        public double rem_descuen_ACT { get; set; }
        public double rem_tramit_ACT { get; set; }
        public double fac_total_ACT { get; set; }
    }
}
