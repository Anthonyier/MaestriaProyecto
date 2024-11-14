using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormRecordatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRecordatorio_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }

        protected void EncontrarDocuPersona()
        {

        }
        protected void EnviarCorreo()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Nombre = "";
            string Ci = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagenes.ObtenerListaPersona();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Nombre = d["Persona"].ToString();
                        Vigencia = Convert.ToDateTime(d["Vigencia"].ToString());
                        Ci = d["CI"].ToString();
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Fini - Vigencia).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " con Nro CI: " + Ci + " de la Persona: " + Nombre + " se encuentra vencido, proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                     }
                    catch (Exception er)
                    {

                    }
                }
            }

            NegImagenes.EnviarMensaje(Mensaje);
        }

        protected void ButtonRecordCamion_Click(object sender, EventArgs e)
        {

        }
    }
}