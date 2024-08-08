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
        public int codUser { get; set; }   // codigo del usuario
        public Boolean indVerFactura { get; set; }  // indicador para ver el módulo de Facturas
        public Boolean indVerActFij { get; set; }   // indicador para ver el módulo de Activos Fijos
        public Boolean indVerSistInf { get; set; }   // indicador para ver el módulo de Sistema de Informacion
        public Boolean indVerNotas { get; set; }  // indicador para ver Pantalla Notas
        public Int16 idEmpresa { get; set; }  // id de la empresa (1: CZF. 2: CNZF)
        public Boolean indCambiarEmpresa { get; set; }  // indicador para cambiar de empresas al entrar al sistema
        public Boolean indVerRepotFact { get; set; }  // indicador para ver reporte de Facturas
        public Boolean indVerFactMes { get; set; }  // indicador para ver reporte de Factura Mes
        public Boolean indVerMtaAnuCli { get; set; }  // indicador para ver reporte de Metraje anual Cliente
        public Boolean indVerFactxMes { get; set; }  // indicador para ver reporte de Factura por Mes 
        public Boolean indVerAntxRegi { get; set; }  // indicador para ver reporte de antiguedad por Regimen
        public Boolean indVerEstCta { get; set; }  // indicador para ver reporte de estado de Cuentas
        public String email { get; set; } // Correo del usuario
        public bool permi_closePantalla { get; set; }
    }
}
