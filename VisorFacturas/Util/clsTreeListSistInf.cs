using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisorFacturas.Clases;

namespace VisorFacturas.Util
{
    public class clsTreeListSistInf
    {

        // Usuario del sistema
        tblUser moCurrentUser;
        /*
            fldidxrep: ID del reporte
            fldcodrep: Código del reporte
            fldnamrep: Nombre del reporte
            fldcia: Empresa
            fldidxrepReportaA: ID del nodo Padre
            fldimageidx = Indice de la imagen (0: imagen con libro cerrado, 1: imagen con libro abierto)
       */

        public static List<viewTreeSistInf> mfxGetTreeList(tblUser moCurrentUser)
        {
            List<viewTreeSistInf> aoTreelst = new List<viewTreeSistInf>();

            if (moCurrentUser.indVerRepotFact)
            {
            
                // Nodo padre Factura
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 1,
                    fldcodrep = "RPT100",
                    fldnamrep = "Reportes de Facturación",
                    fldcia = 2,
                    fldidxrepReportaA = 0,
                    fldimageidx = 0
                });
            }

            if (moCurrentUser.indVerFactMes)
            {
                // Nodo hijo 
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 2,
                    fldcodrep = "RPT101",
                    fldnamrep = "Listado de Facturas Mensual",
                    fldcia = 2,
                    fldidxrepReportaA = 1,
                    fldimageidx = 1
                });
            }
            if (moCurrentUser.indVerMtaAnuCli)
            {
                // Nodo hijo 
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 3,
                    fldcodrep = "RPT102",
                    fldnamrep = "Metraje Anual de Clientes",
                    fldcia = 2,
                    fldidxrepReportaA = 1,
                    fldimageidx = 1
                });
            }
            if (moCurrentUser.indVerFactxMes)
            {
                // Nodo hijo 
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 4,
                    fldcodrep = "RPT103",
                    fldnamrep = "Comparación de Facturas por Mes",
                    fldcia = 2,
                    fldidxrepReportaA = 1,
                    fldimageidx = 1
                });
            }
            if (moCurrentUser.indVerAntxRegi) 
            { 
                // Nodo hijo 
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 5,
                    fldcodrep = "RPT104",
                    fldnamrep = "Antigüedad por Régimen",
                    fldcia = 2,
                    fldidxrepReportaA = 1,
                    fldimageidx = 1
                });
            }
            if (moCurrentUser.indVerEstCta)
            {
                aoTreelst.Add(new viewTreeSistInf()
                {
                    fldidxrep = 6,
                    fldcodrep = "RPT105",
                    fldnamrep = "Estado de Cuenta de Clientes",
                    fldcia = 2,
                    fldidxrepReportaA = 1,
                    fldimageidx = 1
                });
            }
            //// Nodo padre Contabilidad
            //aoTreelst.Add(new viewTreeSistInf()
            //{
            //    fldidxrep = 500,
            //    fldcodrep = "RPT500",
            //    fldnamrep = "Reportes de Contabilidad",
            //    fldcia = 1,
            //    fldidxrepReportaA = 0,
            //    fldimageidx = 0
            //});

            aoTreelst.Add(new viewTreeSistInf()
            {
                fldidxrep = 500,
                fldcodrep = "RPT501",
                fldnamrep = "Anexos Financieros",
                fldcia = 1,
                fldidxrepReportaA = 0,
                fldimageidx = 0
            });            
            aoTreelst.Add(new viewTreeSistInf()
            {
                fldidxrep = 501,
                fldcodrep = "RPT501",
                fldnamrep = "Detalles Comprobantes Contables",
                fldcia = 1,
                fldidxrepReportaA = 500,
                fldimageidx = 1
            });
            aoTreelst.Add(new viewTreeSistInf()
            {
                fldidxrep = 600,
                fldcodrep = "RPT501",
                fldnamrep = "Estados Financieros",
                fldcia = 1,
                fldidxrepReportaA = 0,
                fldimageidx = 0
            });

            return aoTreelst.OrderBy(f => f.fldidxrep).ToList();
        }

    }
}
