using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisorFacturas.Clases;
using VisorFacturas.Enums;

namespace VisorFacturas.Util
{
    public class clslistusers
    {
        public tblUser GetUserSystem(String pausername, Int16? paidempresaselect)
        {
            tblUser createcurrentuser = new tblUser();
            switch (pausername.ToLower())
            {
                case @"zfrancas\adavila":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Ariel Dávila González";
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;

                    //createcurrentuser.indVerFactura = true;
                    //createcurrentuser.indVerActFij = true;
                    //createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    //createcurrentuser.indCambiarEmpresa = false;
                    break;
                case @"zfrancas\wmejia":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "William Mejía Mendoza";
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    break;
                case @"zfrancas\rsblanco":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Ramona Blanco Lezama";
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    break;
                case @"zfrancas\dgonzalez":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "David González Tiffer";
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    break;
                case @"zfrancas\cobando":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Sofía Carolina Obando";
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = false;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    break;
                default:
                    createcurrentuser.username = "Usuario Inválido";
                    createcurrentuser.fullname = "Usuario No Autorizado";
                    createcurrentuser.indVerFactura = false;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = false;
                    createcurrentuser.idEmpresa = 0;
                    createcurrentuser.indCambiarEmpresa = false;
                    break;
            }
            return createcurrentuser;
        }
                
    }
}
