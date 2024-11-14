using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CapaEntidad;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormReportDim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Request.QueryString["Id"];
            if (!IsPostBack)
            {
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}