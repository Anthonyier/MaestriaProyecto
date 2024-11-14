using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocios;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormModificarDim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int IdDim = Convert.ToInt32(Request.QueryString["Id"]);
                    TextIdDIm.Text = Convert.ToString(IdDim);
                    int Id = Convert.ToInt32(TextIdDIm.Text);
                    EntDim ObjDim = new EntDim();
                    ObjDim = NegDim.BuscarDim(Id);
                    TextAduanaFront.Text = ObjDim.AduanaFrontera;
                    TextDim.Text = ObjDim.Dim;
                    TextProductoDim.Text = ObjDim.Producto;
                    TextProveedor.Text = ObjDim.Proveedor;

                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando modificar DIMS";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);

                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas  PerRutas = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);

            if (PerRutas.ProgramaRutas != 1)
            {

                btnGuardar.Visible = false;
                btnGuardar.Enabled = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int Resultado = 0;
            if (TextAduanaFront.Text != "" && TextDim.Text != "" && TextProductoDim.Text != "" && TextProveedor.Text != "")
            {
                string AduanaFronter = TextAduanaFront.Text;
                string Dim = TextDim.Text;
                int IdDim = int.Parse(TextIdDIm.Text);
                string ProductoDim = TextProductoDim.Text;
                string Proveedor = TextProveedor.Text;
                Resultado = NegDim.ModificarDim(IdDim, Dim, ProductoDim, Proveedor, AduanaFronter);
                if (Resultado == 1)
                {
                    Response.Redirect("FormCreacionDim.aspx");
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCreacionDim.aspx");
        }
    }
}