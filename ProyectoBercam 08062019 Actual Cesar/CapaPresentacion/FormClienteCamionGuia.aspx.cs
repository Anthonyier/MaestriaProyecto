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
    public partial class FormClienteCamionGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarPeriodo();
                CargarRegion();
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando crear Detalles De Carros Guia de Bercam";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);
                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosCarroGuias Persona = NegPermisosCarroGuia.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.CrearDetCarGuia != 1)
            {

                BtnGuardar.Visible = false;
                BtnGuardar.Enabled = false;
            }
        }
        public void CargarRegion()
        {
            DdlRegion.Items.Clear();
            DdlRegion.Items.Add(new ListItem("--Seleccione Region--", ""));
            DdlRegion.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Region where Id=1 or Id=2";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlRegion.DataSource = dr; //cmd.ExecuteReader();    
                DdlRegion.DataTextField = "Region";
                DdlRegion.DataValueField = "Id";
                DdlRegion.DataBind();
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
        public void CargarPeriodo()
        {
            DdlPeriodo.Items.Clear();
            DdlPeriodo.Items.Add(new ListItem("--Seleccione Periodo--", ""));
            DdlPeriodo.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Periodo";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlPeriodo.DataSource = dr; //cmd.ExecuteReader();    
                DdlPeriodo.DataTextField = "Quincena";
                DdlPeriodo.DataValueField = "id";
                DdlPeriodo.DataBind();
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

        public void CargarAño()
        {
            DdlAño.Items.Clear();
            DdlAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            DdlAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlAño.DataSource = dr; //cmd.ExecuteReader();    
                DdlAño.DataTextField = "Descripcion";
                DdlAño.DataValueField = "Id";
                DdlAño.DataBind();
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

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntDetalleCarroGuia Carro= new EntDetalleCarroGuia();
            if (TextBoxMontoCarro.Text != "" && TextoClienteCarroGuia.Text != "")
            {
                Carro.Monto = double.Parse(TextBoxMontoCarro.Text);
                Carro.IdPersona = ObtenerPersona(TextoClienteCarroGuia.Text);
                Carro.IdPeriodo = Convert.ToInt32(DdlPeriodo.Text);
                Carro.IdAño = Convert.ToInt32(DdlAño.Text);
                Carro.IdRegion = Convert.ToInt32(DdlRegion.Text);
                EntDetalleCarroGuia RepCarroGuia = new EntDetalleCarroGuia();
                RepCarroGuia = NegDetalleCarroGuia.EncontrarDetalleCarroGuia(Carro.IdPeriodo, Carro.IdAño, Carro.IdPersona,Carro.IdRegion);
                if (RepCarroGuia != null)
                {
                    lblError.Text = "Esta Camion Guia Ya Ha Sido Metido En El Sistema";
                    lblError.Visible = true;
                    return;
                }
                else
                {


                    if (Request.QueryString["Id"] != null)
                    {

                    }
                    else
                    {
                        if (NegDetalleCarroGuia.InsertarDetalleCamionGuia(Carro) == 1)
                        {
                            lblError.Text = "Detalle De Carro Guia satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Detalle De Carro Guia registrada satisfactoriamente');</script>");
                            //Response.Redirect("frmRegistrarPropietarios.aspx");
                            //Cliente.Text = "";
                            TextBoxMontoCarro.Text = "";
                            TextoClienteCarroGuia.Text = "";

                        }
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
    }
}