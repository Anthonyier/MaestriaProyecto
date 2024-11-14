using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormListaMultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DtgListaMulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarMulta")
            {
               
                    string sPersonaId = e.CommandArgument.ToString();
                    Response.Redirect("FormMulta.aspx?Id=" + sPersonaId);
                
            }
            
            if (e.CommandName == "DeshabilitarMulta")
            {
               
               
                    string sMultaId = e.CommandArgument.ToString();
                    NegMulta.Deshabilitar(int.Parse(sMultaId));
                    Response.Write("<script languaje =javascript>alert ('Deshabilitado satisfactoriamente');</script>");
               
            }
        }
    }
}