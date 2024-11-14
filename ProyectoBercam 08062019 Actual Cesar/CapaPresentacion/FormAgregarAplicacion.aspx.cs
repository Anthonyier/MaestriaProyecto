using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FormAgregarAplicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (PerRutas.Aplicacion != 1)
            {
                GriedView1.Visible = false;
                GriedView1.Enabled = false;
            }
        }
        protected void DtgGridViewListAplicacionDim_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntUsuario Usuario = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + ' ' + us.Apellidos;
            bit.Accion = "El usuario esta intentando Cerrar un DIM";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);
            EntPermisoRutas Perm = NegPermisoRutas.BuscarPermiso(Usuario.Id_Usuario);
            if (e.CommandName == "CrearAplicacion")
            {
                string IdDIM = e.CommandArgument.ToString();
                Response.Redirect("FormCreacionAplicacion.aspx?Id=" + IdDIM);
            }
        }
    }
}