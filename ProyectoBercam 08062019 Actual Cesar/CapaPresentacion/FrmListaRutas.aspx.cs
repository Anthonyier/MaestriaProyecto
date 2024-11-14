using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ListaRutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DtgListaRuta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarRuta")
            {
                string sRutaId = e.CommandArgument.ToString();
                Response.Redirect("FormRuta.aspx?Id=" + sRutaId);
            }
            
        }
    }
}