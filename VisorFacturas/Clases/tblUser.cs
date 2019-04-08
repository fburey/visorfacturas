using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisorFacturas.Enums;

namespace VisorFacturas.Clases
{
    public class tblUser
    {
        public String username { get; set; }   // nombre de usuarios
        public String fullname { get; set; }   // nombre completo del usuario
        public Boolean indVerFactura { get; set; }  // indicador para ver el módulo de Facturas
        public Boolean indVerActFij { get; set; }   // indicador para ver el módulo de Activos Fijos
        public Int16 idEmpresa { get; set; }  // id de la empresa (1: CZF. 2: CNZF)
        public Boolean indCambiarEmpresa { get; set; }  // indicador para cambiar de empresas al entrar al sistema      
    }
}
