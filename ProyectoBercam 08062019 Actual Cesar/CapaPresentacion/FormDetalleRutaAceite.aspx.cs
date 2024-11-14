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
    public partial class FormDetalleRutaAceite : System.Web.UI.Page
    {
        int IdPersona = 3381;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarCliente();
                CargarRuta();
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas Persona = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.CrearRuta != 1)
            {

                BtnGuardar.Visible = false;
                BtnGuardar.Enabled = false;
            }

        }
        protected void Calendar_FechaInicialOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFechaInicial.SelectedDate != null)
            {
                TextFechaInicial.Text = CalendarFechaInicial.SelectedDate.ToString("d");
                CalendarFechaInicial.Visible = false;
            }

        }
        public void Calendar_FechaFinalOnSelectionChanged(object sender, EventArgs e)
        {

            if (CalendarFechaFinal.SelectedDate != null)
            {
                TextFechaFinal.Text = CalendarFechaFinal.SelectedDate.ToString("d");
                CalendarFechaFinal.Visible = false;
            }
        }

        public void CargarCliente()
        {
            Cliente.Items.Clear();
            Cliente.Items.Add(new ListItem("--Selecciona Cliente--", ""));
            Cliente.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "select Id_Persona,Nombre+' '+ Apellidos As CLIENTE FROM Persona where ClienteAceite=1";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Cliente.DataSource = dr; //cmd.ExecuteReader();    
                Cliente.DataTextField = "CLIENTE";
                Cliente.DataValueField = "Id_Persona";
                Cliente.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public void CargarRuta()
        {
            Ruta.Items.Clear();
            Ruta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            Ruta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Ruta.DataSource = dr; //cmd.ExecuteReader();    
                Ruta.DataTextField = "Ruta";
                Ruta.DataValueField = "Id_Ruta";
                Ruta.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        protected void imgCalendarFechaInicial_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaInicial.Visible)
            {
                CalendarFechaInicial.Visible = false;
            }
            else
            {
                CalendarFechaInicial.Visible = true;
            }
        }

        protected void imgCalendarFechaFinal_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaFinal.Visible)
            {
                CalendarFechaFinal.Visible = false;
            }
            else
            {
                CalendarFechaFinal.Visible = true;
            }
        }

        protected void Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cliente.Text != "")
            {
                IdPersona = int.Parse(Cliente.Text);
                CargarRuta();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Cliente.Text != "" && Ruta.Text != "" && TextPrecio.Text != "" && TextFletero.Text != "" && TextFechaInicial.Text!="" && TextFechaFinal.Text!="")
            {
                EntDetalleRutaAceite objR = new EntDetalleRutaAceite();
                objR.PrecioTotal = Double.Parse(TextPrecio.Text);
                objR.PrecioFletero = Convert.ToDouble(TextFletero.Text);
                objR.FechaInicio = Convert.ToDateTime(TextFechaInicial.Text);
                objR.FechaFinal = Convert.ToDateTime(TextFechaFinal.Text);
                objR.IdRuta = Int32.Parse(Ruta.Text);
                if (NegDetalleRutaAceite.GuardarDetalleRutaAceite(objR) == true)
                {
                    TextFechaInicial.Text = "";
                    TextFechaFinal.Text = "";
                    TextPrecio.Text = "";
                    TextFletero.Text = "";
                    Response.Write("<script languaje =javascript>alert ('Registro de Detalle Ruta Aceite Insertado satisfactoriamente');</script>");
                    lblError.Text = "Registro de Detalle Ruta Aceite guardado satisfactoriamente";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Text = "No se pudo Guardar el Detalle De Ruta De Aceite por algun motivo, Verifique e";
                    lblError.Visible = true;
                }
            }
        }
    }
}