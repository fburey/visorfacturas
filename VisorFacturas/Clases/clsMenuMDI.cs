using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisorFacturas.Clases
{
    public class clsMenuMDI
    {
        //clsCnfParameterLogin moClsCnfParameter = new clsCnfParameterLogin();
        ////Aqui obtengo si le orden es interna
        //public bool orden_interna { get; set; }
        ////Aqui obtengo el permiso de cerrar las pantallas
        //public bool permi_closePantalla { get; set; }
        public clsCnfParameterLogin CerrarTodosMenosMDI(clsCnfParameterLogin pamoClsCnfParameter)
        {
            try
            {
                int HayFormAbiertos = 0;
                for (int j = 0; j <= Application.OpenForms.Count - 1; j++)//este -1 es para que no aya a quedar fuera del subindice, pues el count se va actualziando a medidda que se eliminan formularios
                {
                    Form form = Application.OpenForms[j];
                    if (form.Name != "")
                    {
                        HayFormAbiertos += 1;
                    }
                }

                if (HayFormAbiertos > 2)
                {
                    if (XtraMessageBox.Show("Las pantallas abiertas, se cerraran automáticamente", "Pantalla Abiertas", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return pamoClsCnfParameter;
                    }
                    else
                    {
                        pamoClsCnfParameter.permi_closePantalla = true;
                    }

                }
                else
                {
                    pamoClsCnfParameter.permi_closePantalla = true;
                }
                //Capturo el numero de pantallas abiertas
                int aoCOUNT = Application.OpenForms.Count - 1;
                //Se hace habiendo detectado o no formaulario abiertos
                //esta parte cierra todos los form menos MDI.
                for (int i = aoCOUNT; i > 0; i--)
                {
                    Form form = Application.OpenForms[i];
                    if ((form.Name != "frmmain") && (form.Name != ""))
                    {
                        form.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Precaución. " + ex.Message, "Error al cerrar las pantallas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pamoClsCnfParameter;
        }
    }
}
