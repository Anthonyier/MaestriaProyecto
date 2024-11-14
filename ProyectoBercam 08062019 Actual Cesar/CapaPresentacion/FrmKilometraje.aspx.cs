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
    public partial class FrmKilometraje : System.Web.UI.Page
    {
        int IdPersona = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombo();
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (TextKilometraje.Text != "")
            { 
                int idRuta=Convert.ToInt32(DDLRuta.Text);
                EntKilometraje Kilo = new EntKilometraje();
                Kilo = NegKilometraje.RepetidosKilometraje(idRuta);
                if(Kilo!=null)
                {
                    lblError.Text = "No Se Permiten Datos Repetidos";
                    lblError.Visible = true;
                    return;
                }
                Kilo = new EntKilometraje();
                Kilo.IdRuta=Convert.ToInt32(DDLRuta.Text);
                Kilo.Kilometrajes=Convert.ToInt32(TextKilometraje.Text);
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegKilometraje.GuardarKilometraje(Kilo) == 1)
                    {
                        TextKilometraje.Text = "";
                        DDLRuta.Text = "";
                        lblError.Text = "Kilometraje Insertado satisfactoriamente";
                        lblError.Visible = true;

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
            else
            {
                lblError.Text = "No se pudo Insertar el Registro por algun motivo, Verifique e intente nuevamente";
                lblError.Visible = true;
            }
        }
        public void CargarCombo()
        {
            DDLRuta.Items.Clear();
            DDLRuta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            DDLRuta.AppendDataBoundItems = true;
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
                DDLRuta.DataSource = dr; //cmd.ExecuteReader();    
                DDLRuta.DataTextField = "Ruta";
                DDLRuta.DataValueField = "Id_Ruta";
                DDLRuta.DataBind();
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
        

        protected void ButtonRuta_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextClienteKilometraje.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdPersona = int.Parse(d["Id_Persona"].ToString());
                        CargarCombo();
                    }
                    catch (Exception er)
                    {


                    }
                }
            }
        }

        protected void TextClienteKilometraje_TextChanged(object sender, EventArgs e)
        {

        }
    }
}