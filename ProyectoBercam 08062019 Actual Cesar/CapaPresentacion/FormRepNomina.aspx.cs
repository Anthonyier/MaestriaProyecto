﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CapaPresentacion
{
    public partial class FormRepNomina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBus.Text = Request.QueryString["Id"];

        }

        protected void ButonBus_Click(object sender, EventArgs e)
        {
            ReportParameter p = new ReportParameter("Id_Recepcion", TextBus.Text);
            ReportViewer1.LocalReport.SetParameters(p);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}