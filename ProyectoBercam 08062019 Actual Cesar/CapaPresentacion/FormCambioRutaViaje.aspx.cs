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
    public partial class FormCambioRutaViaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int id=Convert.ToInt32(Request.QueryString["Id"]);
                    int ruta = NegRuta.BuscarIdRuta(id);
                    EntRuta obj = new EntRuta();
                    obj = NegRuta.BuscarTodo(ruta);
                    TextRutaActual.Text = obj.Ruta;
                    txtIdCliente.Text = Convert.ToString(obj.Id_Cliente);
                    EntPersona objPers = new EntPersona();
                    objPers = NegPersona.BuscarTodo(obj.Id_Cliente);
                    txtCliente.Text = objPers.Nombres + " " + objPers.Apellidos;
                    CargarRuta(obj.Id_Cliente);
                }
            }
        }
        public void CargarRuta(int IdPersona)
        {
            NuevaRuta.Items.Clear();
            NuevaRuta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            NuevaRuta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                NuevaRuta.DataSource = dr; //cmd.ExecuteReader();    
                NuevaRuta.DataTextField = "Ruta";
                NuevaRuta.DataValueField = "Id_Ruta";
                NuevaRuta.DataBind();
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
        public int Origen()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(NuevaRuta.Text);
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
        protected void NuevaRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NuevaRuta .Text != "")
            {
               int IdRuta = int.Parse(NuevaRuta.Text);
                SqlDataReader d = NegAsignacionRuta.BuscarRuta(NuevaRuta.Text);
                //SqlDataReader r = NegAsignacionRuta.BuscarMonto(Ruta.Text);
                d.Read();
                //r.Read();
                if (d.HasRows == true) //&& r.HasRows==true)
                {
                    if (d != null)// && r!= null)
                    {
                        try
                        {
                            
                            CargarOrigen();
                            CargarDestino();

                        }
                        catch (Exception er)
                        {

                            
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
                DdlDestino.DataTextField = "Planta";
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
        public int Dest()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(NuevaRuta.Text);
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

        protected void BtnModificar_Click(object sender, EventArgs e)
        {

        }

    }
}