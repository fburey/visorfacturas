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

        /*
            fldidxrep: ID del reporte
            fldcodrep: Código del reporte
            fldnamrep: Nombre del reporte
            fldcia: Empresa
            fldidxrepReportaA: ID del nodo Padre
            fldimageidx = Indice de la imagen (0: imagen con libro cerrado, 1: imagen con libro abierto)
       */

        public static List<viewTreeSistInf> mfxGetTreeList()
        {
            List<viewTreeSistInf> aoTreelst = new List<viewTreeSistInf>();

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

            return aoTreelst.OrderBy(f => f.fldidxrep).ToList();
        }

    }
}
