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
    public partial class FormRepConcYpfbPagarInter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.IdUsuario = us.Id_Usuario;
            TextBus.Text = Request.QueryString["Id"];
            if (!IsPostBack)
            {
                ReportParameter p = new ReportParameter("Id", TextBus.Text);
                ReportViewer1.LocalReport.SetParameters(p);
                ReportViewer1.LocalReport.Refresh();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {

                bit.Accion = "El usuario esta intentando Asegurar Las Conciliaciones A Pagar De Corporacion";

                int bi = NegBitacora.GuardarBitacora(bit);
            }

            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(us.Id_Usuario);

            if (Persona.AsegCorp != 1 && Persona.AsegAlc != 1)
            {
                

            }
        }

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportParameter p = new ReportParameter("Id", TextBus.Text);
            ReportViewer1.LocalReport.SetParameters(p);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}