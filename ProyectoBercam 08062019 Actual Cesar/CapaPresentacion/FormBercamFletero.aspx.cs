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
    public partial class FormBercamFletero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeriodo();
                CargarAño();
            }
        }

        public void CargarPeriodo()
        {
            ddlPeriodo.Items.Clear();
            ddlPeriodo.Items.Add(new ListItem("--Selecciona un Periodo--", ""));
            ddlPeriodo.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                string sql = "SELECT * FROM Periodo";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                ddlPeriodo.DataSource = dr; //cmd.ExecuteReader();    
                ddlPeriodo.DataTextField = "Quincena";
                ddlPeriodo.DataValueField = "id";
                ddlPeriodo.DataBind();
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
            DdlAño .Items.Clear();
            DdlAño.Items.Add(new ListItem("--Seleccione un Año--", ""));
            DdlAño.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
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

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPeriodo.Text != null && DdlAño.Text != null)
            {

            }
        }
    }
}