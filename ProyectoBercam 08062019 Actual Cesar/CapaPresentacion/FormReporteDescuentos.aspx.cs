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
    public partial class FormReporteDescuentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        public void CargarFecha(int Id)
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Fecha--", ""));
            cmAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = new SqlCommand("ProcDescBuscFecTitular", cnx);
                cmd.Parameters.AddWithValue("@IdTitular", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr;
                cmAño.DataTextField = "fecha";
                cmAño.DataValueField = "fecha";
                cmAño.DataTextFormatString = "{0:dd-MM-yyyy}";
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
        public void CargarMonto(int id)
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione Monto--", ""));
            cmMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {

                cmd = new SqlCommand("ProcDescBuscFecMonto", cnx);
                cmd.Parameters.AddWithValue("@fecha",Convert.ToDateTime(cmAño.Text));
                cmd.Parameters.AddWithValue("@IdTitular",id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Total";
                cmMes.DataValueField = "monto";
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

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameter = new ReportParameter[3];
            parameter[0] = new ReportParameter("Fecha", cmAño.Text);
            parameter[1] = new ReportParameter("Monto", cmMes.Text);
            parameter[2] = new ReportParameter("Nombre", TextoPlacasDescuenReportes.Text);
            ReportViewer1.LocalReport.SetParameters(parameter);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void TextoPlacasDescuenReportes_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void ButtonFecha_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextoPlacasDescuenReportes.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        int IdTitular = int.Parse(d["Id_Persona"].ToString());
                        CargarFecha(IdTitular);
                        TextHid.Value = Convert.ToString(IdTitular); 
                    }
                    catch (Exception er)
                    {


                    }
                }
            }
        }

        protected void cmMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMonto(Convert.ToInt32(TextHid.Value));
        }

        protected void TextHid_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}