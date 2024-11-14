using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormReporteDeTelefonos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGeneral_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormReporteTelefonoGeneral.aspx");
        }

        protected void ButtonLibre_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormReporteDeTelefonoLibre.aspx");
        }

        protected void ButtonOcupado_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormReporteDeTelefonoOcupado.aspx");
        }

        protected void ButtonCamion_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormReporteTelefonoCamiones.aspx");
        }
    }
}