using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormSeguroCamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoCamiones Persona = NegPermisoCamiones.BuscarPermiso(usuario.Id_Usuario);
            if (Persona.CrearCamion != 1)
            {

                BtnQuitar.Visible = false;
                BtnQuitar.Enabled = false;
                BtnSeguro.Visible = false;
                BtnSeguro.Enabled = false;
            }
        }

        protected void BtnSeguro_Click(object sender, EventArgs e)
        {
            bool Seg = NegCamiones.DarSeguro(TxtPlacaSeguro.Text);
            if (Seg == true)
            {
                lblError.Text = "Seguro Dado";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "El Camion ya tiene seguro";
                lblError.Visible = true;
            }
        }

        protected void BtnQuitar_Click(object sender, EventArgs e)
        {
            bool Seg = NegCamiones.QuitarSeguro(TxtPlacaSeguro.Text);
            if (Seg == true)
            {
                lblError.Text = "Seguro Quitado";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "El Camion actualmente no tiene seguro";
                lblError.Visible = true;
            }
        }
    }
}