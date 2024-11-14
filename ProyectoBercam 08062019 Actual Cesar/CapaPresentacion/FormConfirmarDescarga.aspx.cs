using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormConfirmarDescarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar_DesCargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarDesCarga.SelectedDate != null)
            {
                TextDesCarga.Text = CalendarDesCarga.SelectedDate.ToString("d");
                CalendarDesCarga.Visible = false;
            }

        }

        protected void imgCalendarDesCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarDesCarga.Visible)
            {
                CalendarDesCarga.Visible = false;
            }
            else
            {
                CalendarDesCarga.Visible = true;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int IdDetalle = Convert.ToInt32(Request.QueryString["Id"]);
            DateTime FechaDescarga = Convert.ToDateTime(TextDesCarga.Text);
            string Placa = NegAsignacionRuta.BuscarPlacaConfirmar(IdDetalle);
            int Ruta = NegAsignacionRuta.BuscarRutaConfirmar(IdDetalle);

            bool  ConfRep = NegAsignacionRuta.BuscarConfirmacionDescarga(Placa, FechaDescarga, Ruta);
                if (ConfRep ==true)
                {
                    lblError.Text = "Esta Programacion ya ha sido metida";
                    lblError.Visible = true;
                    return;
                }
            EntUsuario Usuario=(EntUsuario)Session["Usuario"];
            int idUsuario=Usuario.Id_Usuario;
            NegAsignacionRuta.ModificarFechaDescarga(IdDetalle, FechaDescarga, idUsuario);
            lblError.Text = "Modificacion De Fecha De Descarga";
            lblError.Visible = true;
            Response.Redirect("FormListaConfirmarViajeInternacional");
        }
    }
}