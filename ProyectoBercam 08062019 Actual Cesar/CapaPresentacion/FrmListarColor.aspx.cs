﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ListarColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DtgListaColor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarColor")
            {
                string ColorId = e.CommandArgument.ToString();
                Response.Redirect("FormColor.aspx?Id=" + ColorId);
            }
          
        }
    }
}