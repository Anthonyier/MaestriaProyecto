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
    public partial class FormDetRuta : System.Web.UI.Page
    {
        int IdPersona = 9;
        public string ListRutas = "";
        public string ListCli2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCliente();
                CargarRuta();
                //CompCli();
                CargarProducto();
                //CompRutas();
            }
            
         
        }

        //public void CompRutas()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    ClaseConexion Conexion = new ClaseConexion();
        //    SqlConnection cnx = Conexion.conectar();
        //    cmd = new SqlCommand("ProcEncCliente", cnx);
        //    cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.CommandType = CommandType.Text;
        //    //cmd.CommandText = sql;
        //    //cmd.Connection = cnx;
        //    SqlDataReader reader = null;
        //    cnx.Open();
        //    //cmd.Transaction = myTrans;
        //    reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {

        //        if (string.IsNullOrEmpty(ListRutas))
        //        {
        //            ListRutas += "\"" + reader["Ruta"].ToString() + "\"";

        //        }
        //        else
        //        {
        //            ListRutas += ", \"" + reader["Ruta"].ToString() + "\"";

        //        }

        //    }
        //    reader.Close();
        //}

        public void CargarProducto()
        {
            Producto.Items.Clear();
            Producto.Items.Add(new ListItem("--Selecciona Producto--", ""));
            Producto.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * From Producto";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Producto.DataSource = dr; //cmd.ExecuteReader();    
                Producto.DataTextField = "Descripcion";
                Producto.DataValueField = "Id_Producto";
                Producto.DataBind();
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
            TextCli.Items.Clear();
            TextCli.Items.Add(new ListItem("--Selecciona Cliente--", ""));
            TextCli.AppendDataBoundItems = true;
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
                TextCli.DataSource = dr; //cmd.ExecuteReader();    
                TextCli.DataTextField = "CLIENTE";
                TextCli.DataValueField = "Id_Persona";
                TextCli.DataBind();
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

        public void CargarRuta()
        {
            Ruta.Items.Clear();
            Ruta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            Ruta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcEncCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Ruta.DataSource = dr; //cmd.ExecuteReader();    
                Ruta.DataTextField = "Ruta";
                Ruta.DataValueField = "Id_Ruta";
                Ruta.DataBind();
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
            EntDetalleRuta DetRuta = new EntDetalleRuta();
            if(Producto.Text=="" || Ruta.Text=="")
            {
                lblError.Text = "Producto o ruta estan vacios por favor coloque Datos";
            }
            else
            {
                DetRuta.IdProducto = int.Parse(Producto.Text);
                DetRuta.IdRuta = int.Parse(Ruta.Text);
                DetRuta.MermaMaxima = Convert.ToDouble(TextMerma.Text);
                DetRuta.MultaProducto = Convert.ToDouble(TextMulta.Text);
            }
            if (NegRuta.InsertarDetalleRuta(DetRuta) == 1)
            {
                Producto.Text = "";
                Ruta.Text = "";
                Response.Write("<script languaje =javascript>alert ('Registro de Detalle de ruta GUARDADO satisfactoriamente');</script>");
            }
            else
            {
                lblError.Text = "No se pudo insertar el detalle de ruta, Verifique e intente nuevamente";
                lblError.Visible = true;
            }

        }

        //public void CompCli()
        //{

        //    string queryString = "SELECT * FROM vi_Cliente  ORDER BY Cliente";

        //    using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin)) //ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
        //    {

        //        using (SqlCommand command = new SqlCommand(queryString, connection))
        //        {

        //            connection.Open();

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {

        //                while (reader.Read())
        //                {

        //                    if (string.IsNullOrEmpty(ListCli2))
        //                    {
        //                        ListCli2 += "\"" + reader["CLIENTE"].ToString() + "\"";
        //                        //ListClientes += "\"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
        //                    }
        //                    else
        //                    {
        //                        ListCli2 += ", \"" + reader["CLIENTE"].ToString() + "\"";
        //                        //ListClientes += ", \"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
        //                    }

        //                }
        //            }
        //        }

        //    }
        //}
        protected void TextCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
             IdPersona = int.Parse(TextCli.Text);
             CargarRuta();      
        }

        
    }
}