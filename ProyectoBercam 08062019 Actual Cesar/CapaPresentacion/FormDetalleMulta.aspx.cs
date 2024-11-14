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
    public partial class DetalleMulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMulta();
                CargarPeriodo();
                CargarAño();
                CargarRegion();
            }
        }

        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFecha.SelectedDate != null)
            {
                TextFecha.Text = CalendarFecha.SelectedDate.ToString("d");
                CalendarFecha.Visible = false;
            }

        }

        public void CargarMulta()
        {
            DdlMulta.Items.Clear();
            DdlMulta.Items.Add(new ListItem("--Seleccione Multa--", ""));
            DdlMulta.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Multa";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlMulta.DataSource = dr; //cmd.ExecuteReader();    
                DdlMulta.DataTextField = "Numero";
                DdlMulta.DataValueField = "id";
                DdlMulta.DataBind();
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
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFecha.Visible)
            {
                CalendarFecha.Visible = false;
            }
            else
            {
                CalendarFecha.Visible = true;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int IdCamion = 0;
            EntDetalleMulta DetMul = new EntDetalleMulta();
            if (TextoPlacaC.Text != "" && DdlMulta.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarCamion(TextoPlacaC.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            IdCamion = int.Parse(d["Id_Camion"].ToString());

                        }
                        catch (Exception er)
                        {

                        }
                    }
                }

                DetMul.IdCamion = IdCamion;
                DetMul.Precio = double.Parse(txtPrecio.Text);
                DetMul.IdMulta = Convert.ToInt32(DdlMulta.Text);
                DetMul.IdPeriodo = Convert.ToInt32(DdlPeriodo.Text);
                DetMul.IdAño = int.Parse(DdlAño.Text);
                DetMul.IdRegion = Convert.ToInt32(DdlRegion.Text);
                try
                {
                    DetMul.Fecharegistro = Convert.ToDateTime(TextFecha.Text);
                }
                catch (Exception ex)
                {
                    DetMul.Fecharegistro = Convert.ToDateTime(DateTime.Now.ToString());
                }
                if (Request.QueryString["Id"] != null)
                {

                }
                else
                {
                    if (NegDetalleMulta.InsertarDetaMulta(DetMul, txtOBS.Text, TextoPlacaC.Text) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Asignacion de RUTA registrada satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Asignacion de RUTA registrada satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        //Cliente.Text = "";
                        TextoPlacaC.Text = "";
                        txtOBS.Text = "";
                        TextFecha.Text = "";
                        DdlMulta.Text = "";
                    }
                }
            }
        }

        protected void DdlMulta_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DdlMulta.Text != "")
            {
                EntMulta Mu = new EntMulta();
                int IdMulta = Convert.ToInt32(DdlMulta.Text);
                Mu = NegMulta.BuscarMulta(IdMulta);
                //SqlDataReader r = NegAsignacionRuta.BuscarMonto(Ruta.Text);
                txtPrecio.Text = Convert.ToString(Mu.Multa);
            }
        }

        protected void ButtonMulta_Click(object sender, EventArgs e)
        {
            string strJavaScript = "<script> window.open('FormConceptoMulta.aspx?Id=" + DdlMulta.Text + "'); </script>";
            Response.Write(strJavaScript);
        }
    }
}