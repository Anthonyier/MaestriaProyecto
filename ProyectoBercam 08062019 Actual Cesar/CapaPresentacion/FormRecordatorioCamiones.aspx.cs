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
    public partial class FormRecordatorioCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void EnviarCorreo()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamiones();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());
                        
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Fini - Vigencia).Days;
                        if (DiffResult <= 30)
                        {
                         string  Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra vencido, proceda a actualizar el mismo.\n";
                         Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensaje(Mensaje);
        }
        protected void ButtonRecordCamion_Click(object sender, EventArgs e)
        {
            EnviarCorreo();
        }
    }
}