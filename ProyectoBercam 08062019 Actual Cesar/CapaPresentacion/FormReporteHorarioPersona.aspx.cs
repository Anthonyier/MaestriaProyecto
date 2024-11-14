using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CapaPresentacion
{
    public partial class FormReporteHorarioPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextFechaHorario.Text= Request.QueryString["Fecha"];
            
            if (!IsPostBack)
            {
                ReportParameter p = new ReportParameter("fecha", TextFechaHorario.Text );
                ReportViewer1.LocalReport.SetParameters(p);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void TextFechaHorario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}