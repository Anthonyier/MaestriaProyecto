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
    public partial class FormCamioGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarPeriodo();
                CargarProveedor();
                CargarRegion();
                if (Request.QueryString["Id"] != null)
                {
 
                }
                else
                {
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando crear Carros Guia de Bercam";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);
                }
            }

            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosCarroGuias Persona = NegPermisosCarroGuia.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.CrearCarroGuia != 1)
            {

                BtnGuardar.Visible = false;
                BtnGuardar.Enabled = false;
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
                string sql = "SELECT * FROM Region";
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
        public void CargarProveedor()
        {
            DdlProveedor.Items.Clear();
            DdlProveedor.Items.Add(new ListItem("--Seleccione Proovedor--", ""));
            DdlProveedor.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM vi_ListaProveedores";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlProveedor.DataSource = dr; //cmd.ExecuteReader();    
                DdlProveedor.DataTextField = "Nombre";
                DdlProveedor.DataValueField = "Id_Proveedores";
                DdlProveedor.DataBind();
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
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextMonto.Text != "")
            {
                EntCamionGuia Guia = new EntCamionGuia ();
                Guia.Id_Guia = NegCamionGuia.MaximoCam()+1;
                Guia.Monto = Convert.ToDouble(TextMonto.Text);
                Guia.Año = int.Parse(DdlAño.Text);
                Guia.Periodo = int.Parse(DdlPeriodo.Text);
                Guia.Id_Proveedor = Convert.ToInt32(DdlProveedor.Text);
                Guia.IdRegion = Convert.ToInt32(DdlRegion.Text);
                EntCamionGuia RepGuia = NegCamionGuia.EncontrarRepetidoCamionGuia(Guia.Periodo, Guia.Año, Guia.Id_Proveedor, Guia.IdRegion);
                if (RepGuia != null)
                {
                    lblError.Text="Este Camion Guia Ya Sido Metido En EL Sistema";
                    lblError.Visible = true;
                    return;
                }
                if (Request.QueryString["Id"] != null)
                {
                    Guia.Id_Guia = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegCamionGuia.ActualizarCamionGuia(Guia)== 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        //lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Camion Guia ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");

                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Camion Guia por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (NegCamionGuia.InsertarCamionGuia(Guia)==1)
                    {
                        Response.Write("<script languaje =javascript>alert ('Registro de Multa Guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextMonto.Text = "";
                        DdlAño.Text = "";
                        DdlPeriodo.Text = "";
                        DdlProveedor.Text = "";
                        DdlRegion.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Camion Guia por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }
    }
}