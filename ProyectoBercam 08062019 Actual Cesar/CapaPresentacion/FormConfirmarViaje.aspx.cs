using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormConfirmarViaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmAño.Text = DateTime.Now.Year.ToString();
                if (Request.QueryString["Month"] != null)
                {
                    string Dia = Request.QueryString["Day"];
                    string Mes = Request.QueryString["Month"];
                    string Año = Request.QueryString["Year"];
                    string Fecha=Dia+"/"+Mes+"/"+Año;
                    DateTime FechaDetalle = Convert.ToDateTime(Fecha);
                    cmMes.Text = FechaDetalle.Month.ToString();
                    TextDia.Text = FechaDetalle.Day.ToString();
                    cmAño.Text = FechaDetalle.Year.ToString();
                }
                
            }
            
        }

        public void CargarAño()
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr;
                cmAño.DataTextField = "Descripcion";
                cmAño.DataValueField = "Descripcion";
                cmAño.DataBind();
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

        public Boolean RepetidosPorConfirmar(int IdDetalle)
        {
            String Placa = NegAsignacionRuta.BuscarPlacaConfirmar(IdDetalle);
            DateTime Fecha = NegAsignacionRuta.BuscarFechaCargaConfirmar (IdDetalle);
            int Ruta = NegAsignacionRuta.BuscarRutaConfirmar(IdDetalle);
            SqlDataReader bd = NegAsignacionRuta.BuscarProgramacion(Placa, Ruta, Fecha);
            bd.Read();
            if (bd.HasRows == true)
            {
                if (bd != null)
                {
                    lblError.Text = "Esta Programacion ya ha sido metida";
                    lblError.Visible = true;
                    return true;
                }
            }
            return false;
        }
        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            cmMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Mes";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Descripcion";
                cmMes.DataValueField = "Id";
                cmMes.DataBind();
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
        protected void DtgListaConfirmarViaje_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas Per = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (e.CommandName == "Confirmar")
            {
                string RecepcionId = e.CommandArgument.ToString();
                int IdDetalle = int.Parse(RecepcionId);
                if (RepetidosPorConfirmar(IdDetalle) == false)
                {
                    NegAsignacionRuta.ConfirmarViaje(int.Parse(RecepcionId));
                    Response.Write("<script languaje =javascript>alert ('Se ha confirmado la Programacion');</script>");
                }
                
            }
            if (e.CommandName == "ConfirmarFecha")
            {
                if (Per.ConfirmarRuta == 1) 
                {
                    string RecepcionId = e.CommandArgument.ToString();
                    int IdCliente = NegAsignacionRuta.IdDetalleCliente(Convert.ToInt32(RecepcionId));
                    if (IdCliente != 6730)
                    {
                        Response.Redirect("FormConfirmarProgramacionFecha.aspx?Id=" + RecepcionId + "&Modo=" + 1);
                    }
                    else
                    {
                        Response.Write("<script languaje =javascript>alert ('Este viaje es internacional tiene que ser confirmado por Mic');</script>");
                    }
                    
                }
                
            }
            if (e.CommandName == "ConfirmarMic")
            {
                if (Per.ConfirmarRuta == 1)
                {
                    string recepcionId = e.CommandArgument.ToString();
                    int IdCliente = NegAsignacionRuta.IdDetalleCliente(Convert.ToInt32(recepcionId));
                    if (IdCliente == 6730)
                    {
                        Response.Redirect("FormConfirmarProgMic.aspx?Id=" + recepcionId + "&Modo=" + 1);
                    }
                    else
                    {
                        Response.Write("<script languaje =javascript>alert ('Este viaje no es internacional, tiene que ser confirmado de manera normal');</script>");
                    }
                }
            }
            if (e.CommandName == "NoDespachado")
            {
                if (Per.NoDespachado == 1)
                {
                    string RecepcionId = e.CommandArgument.ToString();
                    NegAsignacionRuta.NoDespachado(int.Parse(RecepcionId));
                    Response.Write("<script languaje =javascript>alert ('No se ha despachado la programacion');</script>");
                }
               
            }
        }
    }
}