using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormEditarMermas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int Id = Convert.ToInt32(Request.QueryString["Id"]);
                    EntDetalleRuta Obj = NegRuta.BuscarDetalleRuta(Id);
                    TextPrecioMerma.Text = Convert.ToString(Obj.MultaProducto);
                }
            }
        }

        protected void ButtonModificar_Click(object sender, EventArgs e)
        {
            EntDetalleRuta obj = new EntDetalleRuta();
            if (Request.QueryString["Id"] != null)
            {
                obj.Id = Convert.ToInt32(Request.QueryString["Id"]);
                obj.MultaProducto = double.Parse(TextPrecioMerma.Text);
                if (NegRuta.ActualizarMerma(obj)==1) {
                    lblError.Text = "Detalle De Ruta ACTUALIZADO satisfactoriamente";
                    lblError.Visible = true;
                    Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                    TextPrecioMerma.Text = "";
                    Response.Redirect("FormListaMermaDetalle.aspx");
                }
                else
                {
                    lblError.Text = "No se pudo ACTUALIZAR el Detalle De Ruta por algun motivo, Verifique e intente nuevamente";
                    lblError.Visible = true;

                }

            }
        }
    }
}