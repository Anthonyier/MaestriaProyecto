using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FormEstCami : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DtgEstCami_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="MandarPlaca")
            {
                //Server.Transfer("FormAsignacionRuta.aspx");
                //string Placa = e.CommandArgument.ToString();
                
                //if (PreviousPage!=null)
                //{
                    
                //}
            }
        }
    }
}