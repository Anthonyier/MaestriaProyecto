using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormListaTransacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void DtgListaTransacciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarTransaccion")
            {
                string TransaccionId = e.CommandArgument.ToString();
                Response.Redirect("FormTransaccion.aspx?Id=" + TransaccionId);
            }
        }
    }
}