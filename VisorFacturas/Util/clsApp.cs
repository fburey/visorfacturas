using DevExpress.XtraEditors;
using System.Linq;

namespace VisorFacturas.Util
{
    public class clsApp
    {
        //función genérica que retorna el bóton buscando en un NAVIGATOR
        public static NavigatorCustomButton mfxDtanavGetBtn(ControlNavigator poctrlnav, string pcval)
        {
            //Obtener el boton de visualizar, utilizando LINQ TO OBJECT
            NavigatorCustomButton aobtn = (from aobject in poctrlnav.Buttons.CustomButtons.Cast<NavigatorCustomButton>()
                                           where aobject.Tag.ToString() == pcval
                                           select aobject).ElementAtOrDefault(0);
            return aobtn;
            //clssafrhh.mfxDtanavGetBtn(mmpxformctlnav, "mvxRefresh").Enabled = false;

        }

        public static string mfxMesCadena(short panummes)
        {
            if (panummes == 1)
                return "Enero";
            else if (panummes == 2)
                return "Febrero";
            else if (panummes == 3)
                return "Marzo";
            else if (panummes == 4)
                return "Abril";
            else if (panummes == 5)
                return "Mayo";
            else if (panummes == 6)
                return "Junio";
            else if (panummes == 7)
                return "Julio";
            else if (panummes == 8)
                return "Agosto";
            else if (panummes == 9)
                return "Septiembre";
            else if (panummes == 10)
                return "Octubre";
            else if (panummes == 11)
                return "Noviembre";
            else if (panummes == 12)
                return "Diciembre";
            else
                return "";
        }
    }
}
