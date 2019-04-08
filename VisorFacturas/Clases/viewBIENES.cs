using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class viewBIENES
    {
        public String bicodigo { get; set; }
        public String bi_descrip { get; set; }
        public String bi_marca { get; set; }
        public String bi_modelo { get; set; }
        public String bi_serie { get; set; }
        public String bi_codemp { get; set; }
        public Decimal bi_valor { get; set; }
        public Decimal bi_depacu { get; set; }
        public Decimal bi_saldo { get; set; }
        public Decimal bi_vidautl { get; set; }
        public Decimal bi_cantdep { get; set; }
        public Decimal bi_depmes { get; set; }
    }
}
