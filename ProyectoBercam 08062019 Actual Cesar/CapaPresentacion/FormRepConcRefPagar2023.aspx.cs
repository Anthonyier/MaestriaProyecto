using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;


namespace CapaPresentacion
{
    public partial class FormRepConcRefPagar2023 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            TextBus.Text = Request.QueryString["id"];
            bit.IdUsuario = us.Id_Usuario;
            if (!IsPostBack)
            {
                ReportViewer1.LocalReport.Refresh();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {


                bit.Accion = "El usuario esta intentando Asegurar Las Conciliaciones A Pagar De Refinacion";

                int bi = NegBitacora.GuardarBitacora(bit);
            }
        }

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}