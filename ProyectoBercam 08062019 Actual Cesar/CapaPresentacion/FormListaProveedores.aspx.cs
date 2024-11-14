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
    public partial class FormListaProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoPersona Persona = NegPermisoPersona.BuscarPermiso(usuario.Id_Usuario);
            if (Persona.ListaPersona != 1)
            {
                GridProveedor.Visible = false;
            }
           }
        }
    }
