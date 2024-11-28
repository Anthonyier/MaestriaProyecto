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
    public partial class FormRutaCorta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDestino();
                CargarOrigen();
            }
           
        }
        public void CargarDestino()
        {
            cmDestino.Items.Clear();
            cmDestino.Items.Add(new ListItem("--Seleccione Destino--", ""));
            cmDestino.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Planta";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmDestino.DataSource = dr;
                cmDestino.DataTextField = "Descripcion";
                cmDestino.DataValueField = "Id";
                cmDestino.DataBind();
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
        public void CargarOrigen()
        {
            cmOrigen.Items.Clear();
            cmOrigen.Items.Add(new ListItem("--Seleccione Origen--", ""));
            cmOrigen.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Planta";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmOrigen.DataSource = dr;
                cmOrigen.DataTextField = "Descripcion";
                cmOrigen.DataValueField = "Id";
                cmOrigen.DataBind();
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
            int IdCliente = 0;
            SqlDataReader d = NegAsignacionRuta.BuscarNit(TextCliRutaCorta.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdCliente = Convert.ToInt32(d["Id_Persona"].ToString());
                        int Origen=Convert.ToInt32(cmOrigen.Text);
                        int Destino=Convert.ToInt32(cmDestino.Text);
                        bool Ruta = NegRuta.RutaCorta(Origen, Destino, IdCliente);
                        if (Ruta == true)
                        {
                            lblError.Text = "Logro crearse rutas Cortas";

                        }
                        else
                        {
                            lblError.Text = "No pudo crearse rutas Cortas";
                        }
                    }
                    catch (Exception er)
                    {
                        IdCliente = 0;
                        lblError.Text = "No se Pudo crear la ruta corta";
                        //TxtChofer.Text = "";
                    }
                    
                }
            }
        }

    }
}