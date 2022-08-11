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
        public Boolean indVerSistInf { get; set; }   // indicador para ver el módulo de Sistema de Informacion
        public Boolean indVerNotas { get; set; }  // indicador para ver Pantalla Notas
        public Int16 idEmpresa { get; set; }  // id de la empresa (1: CZF. 2: CNZF)
        public Boolean indCambiarEmpresa { get; set; }  // indicador para cambiar de empresas al entrar al sistema      
        public String email { get; set; } // Correo del usuario
    }
}
