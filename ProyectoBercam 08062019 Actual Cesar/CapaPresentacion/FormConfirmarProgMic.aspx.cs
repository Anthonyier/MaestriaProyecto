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
    public partial class FormConfirmarProgMic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int IdDetalle = Convert.ToInt32(Request.QueryString["Id"]);
                    EntFrontera ObjFrontera = NegFrontera.BuscarFrontera(IdDetalle);
                    if (ObjFrontera.Id != 4)
                    {
                        LabelCrt.Text = ObjFrontera.NroCrt;
                    }
                    else
                    {
                        LabelCrt.Visible = false;
                    }
                    
                    LabelMic.Text = ObjFrontera.NroMic;
                }
            }
        }
        protected void Calendar_CargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCarga.SelectedDate != null)
            {
                TextCarga.Text = CalendarCarga.SelectedDate.ToString("d");
                CalendarCarga.Visible = false;
            }

        }

        protected void imgCalendarCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCarga.Visible)
            {
                CalendarCarga.Visible = false;
            }
            else
            {
                CalendarCarga.Visible = true;
            }
        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int IdDetalle = Convert.ToInt32(Request.QueryString["Id"]);
            DateTime Fecha = Convert.ToDateTime(TextCarga.Text);
            String Placa = NegAsignacionRuta.BuscarPlacaConfirmar(IdDetalle);
            string NoCrt= LabelCrt.Text + txtNoCrt.Text;
            string NoMic= LabelMic.Text + txtNroMic.Text;
            if (LabelCrt.Visible == true)
            {
                NoCrt = LabelCrt.Text + txtNoCrt.Text;
            }
            else
            {
                NoCrt = txtNoCrt.Text;
            }
            double VolumenMic=Convert.ToDouble(txtVolumenMic.Text);
            double PesoMic=Convert.ToDouble(txtPesoMic.Text);
            double VolumeCrt = Convert.ToDouble(txtVolumenCRT.Text);
            double PesoCrt = Convert.ToDouble(txtPesoCRT.Text);
            int Ruta = NegAsignacionRuta.BuscarRutaConfirmar(IdDetalle);

            int Dia = NegAsignacionRuta.ObtenerDiaViaje(IdDetalle);
            int Mes = NegAsignacionRuta.ObtenerMesViaje(IdDetalle);
            int Año = NegAsignacionRuta.ObtenerAñoViaje(IdDetalle);

            bool repetido = NegAsignacionRuta.BuscarConfirmacion(Placa, Fecha, Ruta);
            if (repetido == true)
            {
                    lblError.Text = "Esta Programacion ya ha sido metida";
                    lblError.Visible = true;
                    return;
            }
            NegAsignacionRuta.ConfirmarMic2(NoCrt, NoMic, VolumenMic, PesoMic,IdDetalle,VolumeCrt,PesoCrt);
            //double TotalVolumenCrt = NegAsignacionRuta.ObtenerVolumenCrt(NoCrt);
            //double TotalPesoCrt = NegAsignacionRuta.ObtenerPesoCrt(NoCrt);
            //NegAsignacionRuta.ActualizarPesoVolCrt(NoCrt, TotalVolumenCrt, TotalPesoCrt);
            NegAsignacionRuta.ModificarFecha(IdDetalle, Fecha);
            NegAsignacionRuta.ConfirmarViaje(IdDetalle);
            lblError.Text = "Programacion Confirmada Satisfactoriamente";
            lblError.Visible = true;
            Response.Write("<script languaje =javascript>alert ('Programacion Confirmada Satisfactoriamente');</script>");
            Response.Redirect("FormConfirmarViaje.aspx?Day=" + Dia + "&Month=" + Mes + "&Year=" + Año);
            //EnviarCorreo();
        }

        protected void EnviarCorreo()
        {
            string PersonadId = Request.QueryString["Id"];
            string Mensaje = "";
            string Camion = "";
            string Nombre = "";
            DateTime Fecha = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegAnticipo.ReaderAnticipo(int.Parse(PersonadId));
            int Conf = NegAnticipo.Confirmar(int.Parse(PersonadId));
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Camion = d["Placa"].ToString();
                        Nombre = d["Nombre"].ToString();
                        Fecha = Convert.ToDateTime(d["FechaRegistro"].ToString());
                        DateTime FechAnt = Fecha.Date;
                        Mensaje = Mensaje + "Se Necesita Pagar el Anticipo del Viaje Confirmado De La Fecha: " + " " + FechAnt + " " + " Perteneciente al Camion: " + Camion + " Del Titular " + Nombre;
                    }
                    catch (Exception er)
                    {

                    }
                }

                if (Conf == 0)
                {
                    NegAnticipo.Mensaje(Mensaje);
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            int IdDetalle = Convert.ToInt32(Request.QueryString["Id"]);
            int Dia = NegAsignacionRuta.ObtenerDiaViaje(IdDetalle);
            int Mes = NegAsignacionRuta.ObtenerMesViaje(IdDetalle);
            int Año = NegAsignacionRuta.ObtenerAñoViaje(IdDetalle);
            Response.Redirect("FormConfirmarViaje.aspx?Day=" + Dia + "&Month=" + Mes + "&Year=" + Año);
        }
    }
}