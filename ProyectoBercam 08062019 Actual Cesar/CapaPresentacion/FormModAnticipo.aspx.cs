using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using System.IO;
using CapaNegocios;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaPresentacion
{
    public partial class FormModAnticipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesAnticipos ObjImagen = new EntImagenesAnticipos();
                ObjImagen = NegImagenesAnticipos.ConsultaImagenMod(ImagenId);
                if (ObjImagen != null)
                {
                    TextIdDetalle.Text = Convert.ToString(ObjImagen.IdDetalle);
                }
            }
        }
        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFechaAntc.SelectedDate != null)
            {
                TextFecha.Text = CalendarFechaAntc.SelectedDate.ToString("d");
                CalendarFechaAntc.Visible = false;
            }

        }
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaAntc.Visible)
            {
                CalendarFechaAntc.Visible = false;
            }
            else
            {
                CalendarFechaAntc.Visible = true;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int IdDetalle = Convert.ToInt32(TextIdDetalle.Text);
            DateTime Fecha = Convert.ToDateTime(TextFecha.Text);
            NegImagenesAnticipos.ModificarFechaAnticipo(IdDetalle, Fecha);
            Response.Write("<script languaje =javascript>alert ('Modificacion de Fecha Anticipo lograda exitosamente');</script>");
            lblError.Text = "Se logro Modificar La Fecha De Anticipo";
            lblError.Visible = true;
        }
    }
}