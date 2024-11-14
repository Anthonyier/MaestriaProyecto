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
    public partial class FormAdelantoDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (TextMonto.Text != "")
            {
                int idCamion = 0;
                SqlDataReader d = NegCamiones.BuscarCamion(TextoClienteAdelantoDePago.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            idCamion = int.Parse(d["Id_Camion"].ToString());
                        }
                        catch (Exception er)
                        {

                        }
                    }
                }
                EntAdelantoDePago Adl = new EntAdelantoDePago();
                Adl.Monto = double.Parse(TextMonto.Text);
                Adl.IdPersona = ObtenerPersona(TextoClienteAdelantoDePago.Text);
                Adl.FechaAdelanto = DateTime.Parse(TextAdelanto.Text);
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegAdelantoDePago.InsertarAdelantoDePagos(Adl) == 1)
                    {
                        Response.Write("<script languaje =javascript>alert('Registro de adelanto satisfactoriamente');</script>");
                        TextMonto.Text = "";
                        TextoClienteAdelantoDePago.Text = "";
                        TextAdelanto.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo insertar El adelanto por algun motivo,Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }

        public static int ObtenerPersona(String Nombre)
        {
            int IdPersona = 0;
            SqlDataReader d = NegPersona.BuscarPersona(Nombre);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdPersona = int.Parse(d["Id_Persona"].ToString());
                        return IdPersona;
                    }
                    catch (Exception er)
                    {

                        return 0;
                    }
                }
            }
            return IdPersona;
        }
        protected void Calendar_AdelantoOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarAdelanto.SelectedDate != null)
            {
                TextAdelanto.Text = CalendarAdelanto.SelectedDate.ToString("d");
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
        protected void TextoClienteAdelantoDePago_TextChanged(object sender, EventArgs e)
        {

        }
    }
}