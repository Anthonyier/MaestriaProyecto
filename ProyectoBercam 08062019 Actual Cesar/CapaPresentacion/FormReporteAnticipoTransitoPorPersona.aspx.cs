using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;
using Microsoft.Reporting.WebForms;

namespace CapaPresentacion
{
    public partial class FormReporteAnticipoTransitoPorPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAntPerTransit_Click(object sender, EventArgs e)
        {
            ReportParameter [] parameter=new ReportParameter[1];
            parameter[0] = new ReportParameter("Nombre", TextNombreAnticipoTransitoPorPersona.Text);
            ReportViewer1.LocalReport.SetParameters(parameter);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}