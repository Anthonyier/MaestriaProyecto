using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;


namespace CapaPresentacion
{
    public partial class FormListaAplicacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmdAño.Text = DateTime.Now.Year.ToString();
            }
            if (Request.QueryString["Id"] != null)
            {

                
            }
            else
            {
                EntUsuario Us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = Us.Nombre + "" + Us.Apellidos;
                bit.Accion = "El Usuario Esta viendo la lista de Aplicaciones";
                bit.IdUsuario = Us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
        }
        public void CargarAño()
        {
            cmdAño.Items.Clear();
            cmdAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmdAño.AppendDataBoundItems = true;
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
                cmdAño.DataSource = dr;
                cmdAño.DataTextField = "Descripcion";
                cmdAño.DataValueField = "Descripcion";
                cmdAño.DataBind();
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
        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Periodo--", ""));
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
                cmMes.DataValueField = "id";
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
        protected void DtgListaConciliacionAplicacion_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ImprimirAplicacion")
            {
                string SdimId = e.CommandArgument.ToString();
                Response.Redirect("FormReporteAplicacion.aspx?Id=" + SdimId);
            }
        }
    }
}