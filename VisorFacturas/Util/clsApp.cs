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
    }
}
