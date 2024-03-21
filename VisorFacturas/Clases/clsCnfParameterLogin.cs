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
        public short mcIdEmpresa { get; set; }
        //Variable que controla si el cambio de empresa o usuario es dentro de la aplicacion
        public bool orden_interna { get; set; }
        //Variable que controla el permiso de cerrar las pantallas abiertas
        public bool permi_closePantalla { get; set; }
        //Nombre de la empresa que seleccione el usuario
        public string GetNombreEmpresaSelec { get; set; }
    }
}
