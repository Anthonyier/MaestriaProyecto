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
    public partial class FormHabPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DtgListaPer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "HabilitarPersona")
            {
             
                    string sPersonaId = e.CommandArgument.ToString();
                    NegPersona.Habilitar(int.Parse(sPersonaId));
                    int Prov = NegPersona.ObtenerProveedor(int.Parse(sPersonaId));
                    NegPersona.HabilitarProveedor(Prov);
                    Response.Write("<script languaje =javascript>alert ('Haabilitado satisfactoriamente');</script>");
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}