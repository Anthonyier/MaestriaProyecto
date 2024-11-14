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
    public partial class FormReporteComparacionCobrarPagar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                CargarCliente();
                DdlAño.Text = DateTime.Now.Year.ToString();
            }

        }

        public void CargarAño()
        {
            DdlAño.Items.Clear();
            DdlAño.Items.Add(new ListItem("--Seleccione Año--",""));
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
                DdlAño.DataValueField = "Id";
                DdlAño.DataBind();
                dr.Close();
            }
            catch(Exception ex)
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
            DdlMes.Items.Clear();
            DdlMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            DdlMes.AppendDataBoundItems = true;
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
                DdlMes.DataSource = dr; //cmd.ExecuteReader();    
                DdlMes.DataTextField = "Descripcion";
                DdlMes.DataValueField = "Id";
                DdlMes.DataBind();
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

        public void CargarCliente()
        {
            DdlCliente.Items.Clear();
            DdlCliente.Items.Add(new ListItem("Total","Total"));
            DdlCliente.Items.Add(new ListItem("Refinacion","Refinacion"));
            DdlCliente.Items.Add(new ListItem("Coorporacion", "Coorporacion"));
            DdlCliente.Items.Add(new ListItem("Alcohol DAP", "Alcohol DAP"));
            DdlCliente.Items.Add(new ListItem("DAP Internacional", "DAP Internacional"));
            DdlCliente.Items.Add(new ListItem("INDUSTRIAS DE ACEITE S.A.", "INDUSTRIAS DE ACEITE S.A."));
            DdlCliente.Items.Add(new ListItem("ADM AMERICAS S. DE R.L.", "ADM AMERICAS S. DE R.L."));
            DdlCliente.Items.Add(new ListItem("BUNGE AGRITRADE S.A.", "BUNGE AGRITRADE S.A."));
            DdlCliente.Items.Add(new ListItem("nutrex inc", "nutrex inc"));
            DdlCliente.Items.Add(new ListItem("Carro Guia", "Carro Guia"));
            DdlCliente.Items.Add(new ListItem("YPFB Internacional", "YPFB Internacional"));
            DdlCliente.Items.Add(new ListItem("sidetrans srl", "sidetrans srl"));
            DdlCliente.Items.Add(new ListItem("cargill bolivia s.a.", "cargill bolivia s.a."));
            DdlCliente.AppendDataBoundItems = true;
        }

        protected void ButtonBusqueda_Click(object sender, EventArgs e)
        {

            ReportViewer1.LocalReport.Refresh();
        }
    }
}