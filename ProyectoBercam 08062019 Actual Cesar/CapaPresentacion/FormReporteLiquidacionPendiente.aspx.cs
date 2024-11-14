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
using Microsoft.Reporting.WebForms;


namespace CapaPresentacion
{
    public partial class FormReporteLiquidacionPendiente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                DdlAño.Text = DateTime.Now.Year.ToString();
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
                string sql = "Select * from Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                DdlAño.DataSource = dr;
                DdlAño.DataTextField = "Descripcion";
                DdlAño.DataValueField = "Descripcion";
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
        protected void ButtonBusqueda_Click(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.Refresh();
        }
    }
}