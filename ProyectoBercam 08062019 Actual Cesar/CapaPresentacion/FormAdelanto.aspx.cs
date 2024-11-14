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
    public partial class FormAdelanto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack )
            {
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosAdelantosDePago Persona = NegPermisosAdelantosDePago.BuscarPermiso(usuario.Id_Usuario);
            try
            {
                if (Persona.PagarAdelantoDePago != 1)
                {

                    ButtonGuardar.Visible = false;
                    ButtonGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ButtonGuardar.Visible = false;
                ButtonGuardar.Enabled = false;
            }
        }

        
        public static int ObtenerPersona(string Nombre)
        {
            int IdPersona = 0;
            SqlDataReader d = NegPersona.BuscarPersona(Nombre);
            d.Read();
            if (d != null)
            {
                try
                {
                    IdPersona = int.Parse(d["Id_Persona"].ToString());
                    return IdPersona;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return IdPersona;
        }
        protected void Calendar_AdelantoOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarAdelanto.SelectedDate != null)
            {
                TextFechaDescuento.Text = CalendarAdelanto.SelectedDate.ToString("d");
                CalendarAdelanto.Visible = false;
            }

        }
        protected void imgCalendarAdelanto_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarAdelanto.Visible)
            {
                CalendarAdelanto.Visible = false;
            }
            else
            {
                CalendarAdelanto.Visible = true;
            }
        }
        public double Reemplazar(string num)
        {
            double Decimal = 0;
            string numero = num;
            num = num.Replace(",", ".");
            Decimal = Convert.ToDouble(num);
            return Decimal;
        }
        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (TextMonto.Text != "")
            {
                EntAdelanto Desc = new EntAdelanto();
                Desc.IdTitular = ObtenerPersona(TextoPlacasAdelantos.Text);
                double MontoAdelanto = Reemplazar(TextMonto.Text);
                Desc.Monto = MontoAdelanto;
                Desc.Descripcion = TextDescripcionAdelantos.Text;
                Desc.Fecha = Convert.ToDateTime(TextFechaDescuento.Text);
               
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegAdelanto.InsertarAdelantos(Desc)==1)
                    {
                        Response.Write("<script languaje =javascript>alert('Registro de Descuentos satisfactoriamente');</script>");
                        TextMonto.Text = "";
                        
                    }
                    else
                    {
                        lblError.Text = "No se pudo insertar El Descuento por algun motivo,Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }
    }
}