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
    public partial class FormEliminarClientCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DtgListaElimAsigCamion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
             string sPersonaId = e.CommandArgument.ToString();
             NegAsignacionCamion.EliminarAsignacionCamionGuia(int.Parse(sPersonaId));
             Response.Redirect("FormEliminarClientCamiones.aspx");
            }
        }
    }
}