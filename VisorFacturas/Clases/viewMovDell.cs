using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class viewMovDell
    {
        public String Cuenta { get; set; }
        public String Descripcion { get; set; }
        public DateTime fecha { get; set; }
        public String nodoc { get; set; }
        public String tcom { get; set; }
        public Decimal debito { get; set; }
        public Decimal credito { get; set; }
        public Decimal debito_d { get; set; }
        public Decimal credito_d { get; set; }
        public String tmoneda { get; set; }
        public short aplicado { get; set; }
        public short anno { get; set; }
        public short mes { get; set; }
    }
}
