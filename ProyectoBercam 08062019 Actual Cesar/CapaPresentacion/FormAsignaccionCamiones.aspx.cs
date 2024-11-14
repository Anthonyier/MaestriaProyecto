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
    public partial class FormAsignaccionCamiones : System.Web.UI.Page
    {
        public string ListPlacas = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCliente();
                //CargarCamiones();
                CargarPlacas();
            }
        }

        public void CargarPlacas()
        {
            string queryString = "SELECT * FROM View_Camiones ORDER BY Placa";
            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin)) //ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(ListPlacas))
                            {
                                ListPlacas += "\"" + reader["Placa"].ToString() + "\"";
                            }
                            else
                            {
                                ListPlacas += ", \"" + reader["Placa"].ToString() + "\"";
                            }
                        }
                    }
                }
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
                string sql = "SELECT * FROM Vi_ClienteEnte";
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

        public DataTable GetCliente(int id)
        {
            DataTable dtCliente = new DataTable();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand("ProcAsigCamion", cnx);
                cmd.Parameters.AddWithValue("@IdCamion", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dtCliente.Load(dr);
            }
            catch (Exception e)
            {
                dr = null;
                return dtCliente;
            }

            return dtCliente;
        }


        public void CargarCamiones()
        {
            //Camiones.Items.Clear();
            //Camiones.Items.Add(new ListItem("--Selecciona la Placa--", ""));
            //Camiones.AppendDataBoundItems = true;
            //ClaseConexion Conexion = new ClaseConexion();
            //SqlConnection cnx = Conexion.conectar();
            //SqlCommand cmd = new SqlCommand();
            //try
            //{
            //    string sql = "SELECT * FROM Vi_Camion order by placa asc";
            //    cmd.CommandText = sql;
            //    cmd.Connection = cnx;
            //    SqlDataReader dr = null;
            //    cnx.Open();
            //    //cmd.Transaction = myTrans;
            //    dr = cmd.ExecuteReader();
            //    Camiones.DataSource = dr; //cmd.ExecuteReader();    
            //    Camiones.DataTextField = "Placa";
            //    Camiones.DataValueField = "Id_Camion";
            //    Camiones.DataBind();
            //    dr.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    cmd.Connection.Close();
            //    cmd.Connection.Dispose();
            //}
        }



        protected void ButtonCliente_Click(object sender, EventArgs e)
        {
            if (Cliente.Text != "" && Camiones.Text != "")
            {
                EntAsignacionCamion ObjAsig = new EntAsignacionCamion();
                ObjAsig.IdCamion = int.Parse(lblid.Text);//Camiones.Text);
                ObjAsig.IdCliente = int.Parse(Cliente.Text);
                if (NegAsignacionCamion.InsertarAsignacion(ObjAsig) == 1)
                {
                    DataTable tabla = new System.Data.DataTable();
                    tabla = GetCliente(int.Parse(lblid.Text));//Camiones.Text));
                    GridView1.DataSource = tabla;
                 //   GridView1.Font.Size = sma;
                    GridView1.DataBind();
                    //Response.Redirect("frmPrincipal.aspx");
                    lblError.Text = "Registro de Asignación guardado satisfactoriamente";
                    lblError.Visible = true;
                    Response.Write("<script languaje =javascript>alert ('Registro de Asignación guardado satisfactoriamente');</script>");
                    //Response.Redirect("frmRegistrarPropietarios.aspx");
                    Cliente.Text = "";
                    Camiones.Text = "";
                }
                else
                {
                    lblError.Text = "No se pudo realizar la asignación de camiones";
                    lblError.Visible = true;

                }
            }
            else
            {
                lblError.Text = "Faltan Ingresar campos Obligatorios";
                lblError.Visible = true;
            }
        }

        protected void Camiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tabla = new System.Data.DataTable();
            tabla = GetCliente(int.Parse(lblid.Text));
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

        protected void Camiones_TextChanged(object sender, EventArgs e)
        {
            if (Camiones.Text != "")
            {
            }
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT id_camion, chofer  FROM View_Camiones where Placa = " + "'" + Camiones.Text + "'";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                dr.Read();
                lblid.Text = dr["id_camion"].ToString();
                txtChofer.Text = dr["chofer"].ToString();
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
            DataTable tabla = new System.Data.DataTable();
            tabla = GetCliente(int.Parse(lblid.Text));
            GridView1.DataSource = tabla;
            GridView1.DataBind();
        }

    }
}