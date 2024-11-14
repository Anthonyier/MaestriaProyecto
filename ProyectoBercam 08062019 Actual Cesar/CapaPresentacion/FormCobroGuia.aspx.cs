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
    public partial class FormCobroGuia : System.Web.UI.Page
    {
         System.Data.DataTable tabla;
         System.Data.DataRow row;
         System.Data.DataTable table;
        int IdRuta = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                DdlRuta.AppendDataBoundItems = true;
                CargarCombo();
                CargarAsignacion();
                CargarAño();
                CargarProveedor();
                CargarRegion();
                CargarPeriodo();
                CargarProducto();
                tabla = new System.Data.DataTable();
                GridView1.DataSource = tabla;
                tabla.Columns.Add("Origen", typeof(System.String));
                tabla.Columns.Add("Destino", typeof(System.String));
                tabla.Columns.Add("Producto", typeof(System.String));
                tabla.Columns.Add("Placa", typeof(System.String));
                GridView1.DataBind();
                if (!Page.IsPostBack)
                {
                    table = new System.Data.DataTable();
                    table.Columns.Add("Origen", typeof(System.String));
                    table.Columns.Add("Destino", typeof(System.String));
                    table.Columns.Add("Producto", typeof(System.String));
                    table.Columns.Add("Placa", typeof(System.String));
                    Session.Add("Tabla", table);

                }
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
        public void CargarAsignacion()
        {
            DdlPlaca.Items.Clear();
            DdlPlaca.Items.Add(new ListItem("--Selecciona una Placa--", ""));
            DdlPlaca.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();

            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcAsig", cnx);
                cmd.Parameters.AddWithValue("@IdCliente", 2234);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlPlaca.DataSource = dr; //cmd.ExecuteReader();    
                DdlPlaca.DataTextField = "Placa";
                DdlPlaca.DataValueField = "Id_Camion";
                DdlPlaca.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                DdlPlaca.Text = "No se encontro camion asignado";
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }

        protected void Calendar_CargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCarga.SelectedDate != null)
            {
                TextCarga.Text = CalendarCarga.SelectedDate.ToString("d");
                CalendarCarga.Visible = false;
            }

        }

        protected void imgCalendarCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCarga.Visible)
            {
                CalendarCarga.Visible = false;
            }
            else
            {
                CalendarCarga.Visible = true;
            }
        }
        public void CargarProducto()
        {
            DdlProducto.Items.Clear();
            DdlProducto.Items.Add(new ListItem("--Seleccione Un Producto--", ""));
            DdlProducto.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarProductos", cnx);
                cmd.Parameters.AddWithValue("@Producto", IdRuta);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlProducto.DataSource = dr; //cmd.ExecuteReader();    
                DdlProducto.DataTextField = "Descripcion";
                DdlProducto.DataValueField = "Id_Producto";
                DdlProducto.DataBind();
                dr.Close();
            }
            catch (Exception e)
            {

            }
        }

        public int Origen()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(DdlRuta.Text);
            int Ori = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Ori = int.Parse(dr["Ori"].ToString());
                    }
                    catch (Exception e)
                    {
                        Ori = 0;
                    }
                }
            }
            return Ori;
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["Placa"] = int.Parse(DdlPlaca.Text);
            row["Origen"] = int.Parse(DdlOrigen.Text);
            row["Destino"] = int.Parse(DdlDestino.Text);
            row["Producto"] = double.Parse(DdlProducto.Text);
            table.Rows.Add(row);
            GridView1.DataSource = table;
            GridView1.DataBind();
            Session.Add("Tabla", table);
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            int i = int.Parse(txtFila.Text) - 1;
            DataRow dr = table.Rows[i];
            table.Rows.Remove(dr);
            GridView1.DataSource = table;
            GridView1.DataBind();

        }


        public int Dest()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(DdlRuta.Text);
            int Des = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Des = int.Parse(dr["Des"].ToString());
                    }
                    catch (Exception e)
                    {
                        Des = 0;
                    }
                }
            }
            return Des;
        }

        public string Destino()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(DdlRuta.Text);
            string Des = "";
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Des = dr["Destino"].ToString();
                    }
                    catch (Exception e)
                    {
                        Des = "";
                    }
                }
            }
            return Des;
        }

        public void CargarDestino()
        {
            DdlDestino.Items.Clear();
            DdlDestino.Items.Add(new ListItem("--Seleccione una ubicacion--", ""));
            DdlDestino.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            int Desti = Dest();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("BuscarPlanta", cnx);
                cmd.Parameters.AddWithValue("@Planta", Desti);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlDestino.DataSource = dr; //cmd.ExecuteReader();    
                DdlDestino .DataTextField = "Planta";
                DdlDestino.DataValueField = "Id";
                DdlDestino.DataBind();
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
            DdlOrigen.Items.Clear();
            DdlOrigen.Items.Add(new ListItem("--Seleccione un Origen--", ""));
            DdlOrigen.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            int Or = Origen();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("BuscarPlanta", cnx);
                cmd.Parameters.AddWithValue("@Planta", Or);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlOrigen.DataSource = dr; //cmd.ExecuteReader();    
                DdlOrigen.DataTextField = "Planta";
                DdlOrigen.DataValueField = "Id";
                DdlOrigen.DataBind();
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
        public void CargarCombo()
        {
            DdlRuta.Items.Clear();
            DdlRuta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            DdlRuta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", 2234);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlRuta.DataSource = dr; //cmd.ExecuteReader();    
                DdlRuta.DataTextField = "Ruta";
                DdlRuta.DataValueField = "Id_Ruta";
                DdlRuta.DataBind();
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
            DdlProv.Items.Clear();
            DdlProv.Items.Add(new ListItem("--Seleccione Proveedor--", ""));
            DdlProv.AppendDataBoundItems = true;
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
                DdlProv.DataSource = dr; //cmd.ExecuteReader();    
                DdlProv.DataTextField = "Nombre";
                DdlProv.DataValueField = "Id_Proveedores";
                DdlProv.DataBind();
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

        protected void DdlRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlRuta.Text != "")
            {
                IdRuta = int.Parse(DdlRuta.Text);
                CargarProducto();
                SqlDataReader d = NegAsignacionRuta.BuscarRuta(DdlRuta.Text);
                //SqlDataReader r = NegAsignacionRuta.BuscarMonto(Ruta.Text);
                d.Read();
                //r.Read();
                if (d.HasRows == true) //&& r.HasRows==true)
                {
                    if (d != null)// && r!= null)
                    {
                        try
                        {
                            //TextProd.Text = d["Descripcion"].ToString();
                            CargarOrigen();
                            CargarDestino();

                        }
                        catch (Exception er)
                        {

                            //TextProd.Text = "";
                            
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        //TextProd.Text = "";
                    }
                }
                else
                {

                    //TextProd.Text = "";
                }
            }
            else
            {
                //TextProd.Text = "";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}