using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class viewRemision
    {
        public String rem_numero { get; set; }
        public String rem_codig { get; set; }
        public String rem_desc { get; set; }
        public Decimal rem_canti { get; set; }
        public Decimal rem_precio { get; set; }
        public Decimal rem_impues { get; set; }
        public Decimal rem_descue { get; set; }
        public DateTime rem_fec_ve { get; set; }
        
    }
}
