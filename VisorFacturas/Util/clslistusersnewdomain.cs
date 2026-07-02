using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisorFacturas.Clases;
using VisorFacturas.Enums;

namespace VisorFacturas.Util
{
    public class clslistusersnewdomain
    {
        public tblUser GetUserSystem(String pausername, Int16? paidempresaselect)
        {
            tblUser createcurrentuser = new tblUser();
            switch (pausername.ToLower())
            {
                case @"czfrancas\adavila":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Ariel Dávila González";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    createcurrentuser.email = "adavila@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;

                    //createcurrentuser.indVerFactura = true;
                    //createcurrentuser.indVerActFij = true;
                    //createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    //createcurrentuser.indCambiarEmpresa = false;
                    break;
                case @"czfrancas\wmejia":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "William Mejía Mendoza";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    createcurrentuser.email = "wmejia@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;
                case @"czfrancas\jmarcia":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Jimmy Marcia Galindo";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    createcurrentuser.email = "jimmy.marcia@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;

                case @"czfrancas\aurey":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Angel Urey Ruiz";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    createcurrentuser.email = "angel.urey@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;

                case @"czfrancas\rsblanco":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Ramona Blanco Lezama";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = false;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.email = "rblanco@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;
                case @"czfrancas\aaviles":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Augusto Avilés";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = false;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.email = "aaviles@cnzf.gob.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;
                case @"czfrancas\dgonzalez":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "David González Tiffer";
                    createcurrentuser.codUser = 252;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = false;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = true;
                    createcurrentuser.email = "dgonzalez@cnzf.gob.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;
                case @"czfrancas\mpineda":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Marjoury Pineda";
                    createcurrentuser.codUser = 342;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = true;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = false;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CNZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.email = "mpineda@cnzf.gob.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = true;
                    createcurrentuser.indVerFactMes = true;
                    createcurrentuser.indVerMtaAnuCli = true;
                    createcurrentuser.indVerFactxMes = true;
                    break;
                case @"czfrancas\ldelgado":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Luis Delgado";
                    createcurrentuser.codUser = 72;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.email = "ldelgado@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = false;
                    createcurrentuser.indVerFactMes = false;
                    createcurrentuser.indVerMtaAnuCli = false;
                    createcurrentuser.indVerFactxMes = false;
                    break;
                case @"czfrancas\laguirre":
                    createcurrentuser.username = pausername;
                    createcurrentuser.fullname = "Lisseth Aguirre";
                    createcurrentuser.codUser = 336;
                    createcurrentuser.indVerFactura = true;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = true;
                    createcurrentuser.indVerNotas = true;
                    createcurrentuser.idEmpresa = paidempresaselect != null ? (Int16)paidempresaselect : (Int16)clsAppEnum.MvxEmpresaSistema.CZF;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.email = "laguirre@czf.com.ni";
                    createcurrentuser.indVerAntxRegi = true;
                    createcurrentuser.indVerEstCta = true;
                    createcurrentuser.indVerRepotFact = false;
                    createcurrentuser.indVerFactMes = false;
                    createcurrentuser.indVerMtaAnuCli = false;
                    createcurrentuser.indVerFactxMes = false;
                    break;

                default:
                    createcurrentuser.username = "Usuario Inválido";
                    createcurrentuser.fullname = "Usuario No Autorizado";
                    createcurrentuser.codUser = 0;
                    createcurrentuser.indVerFactura = false;
                    createcurrentuser.indVerActFij = false;
                    createcurrentuser.indVerSistInf = false;
                    createcurrentuser.indVerNotas = false;
                    createcurrentuser.idEmpresa = 0;
                    createcurrentuser.indCambiarEmpresa = false;
                    createcurrentuser.indVerAntxRegi = false;
                    createcurrentuser.indVerEstCta = false;
                    break;
            }
            return createcurrentuser;

        }
    }
}
