using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisorFacturas.Clases
{
    public class clsCnfParameterLogin
    {
        //Si el usuario se autentico
        public bool mlIsLogIn { get; set; }
        //usuario de la Base de datos
        public string mcCoduserdb { get; set; }
        //Usuario de Windows
        public string mcCoduserso { get; set; }
    }
}
