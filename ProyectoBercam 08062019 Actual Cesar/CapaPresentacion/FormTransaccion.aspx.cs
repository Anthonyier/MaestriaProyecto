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
    public partial class FormTransaccion : System.Web.UI.Page
    {
        double Monto = 0;
        double TipoCambio = 0;
        string Glosa = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
         
                CargarCuenta();
                CargarFormarPago();
                CargarMoneda();
                CargarTipoTransaccion();

            }
            if (Request.QueryString["Id"] != null)
            {
                Glosa = TextGlosa.Text;
                if (Textmonto.Text == "")
                {
                    Monto = 0;
                }
                else
                {
                    Monto = double.Parse(Textmonto.Text);
                }
                if (TextTipoCambio.Text == "")
                {
                    TipoCambio = 0;
                }
                else
                {
                    TipoCambio = double.Parse(TextTipoCambio.Text);
                }
                int TransaccionId = Convert.ToInt32(Request.QueryString["Id"]);
                EntTransaccion tran = new EntTransaccion();
                tran = NegTransaccion.BuscarTransaccion(TransaccionId);
                Textmonto.Text = Convert.ToString(tran.Monto);
                TextTipoCambio.Text = Convert.ToString(tran.TipoCambio);
                TextGlosa.Text = tran.Glosa;
                ddlMoneda.Text = Convert.ToString(tran.IdMoneda);
                ddlFormaPago.Text = Convert.ToString(tran.IdFormaPago);
                ddlCuenta.Text = Convert.ToString(tran.IdCuenta);
                ddlTipoTransaccion.Text = Convert.ToString(tran.IdTipoTransaccion);


            }
        }

        public void CargarMoneda()
        {
            ddlMoneda.Items.Clear();
            ddlMoneda.Items.Add(new ListItem("--Seleccione Moneda"));
            ddlMoneda.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                String sql = "Select * from Moneda";
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
              
                dr = cmd.ExecuteReader();
                ddlMoneda.DataSource = dr; 
                ddlMoneda.DataTextField = "Descripccion";
                ddlMoneda.DataValueField = "IdMoneda";
                ddlMoneda.DataBind();
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
        public void CargarFormarPago()
        {
            ddlFormaPago.Items.Clear();
            ddlFormaPago.Items.Add(new ListItem("--Seleccione Forma de pago--"));
            ddlFormaPago.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                String sql = "Select * from FormaPago";

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();

                dr = cmd.ExecuteReader();
                ddlFormaPago.DataSource = dr;
                ddlFormaPago.DataTextField = "Descripcion";
                ddlFormaPago.DataValueField = "IdFormaPago";
                ddlFormaPago.DataBind();
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
        public void CargarCuenta()
        {
            ddlCuenta.Items.Clear();
            ddlCuenta.Items.Add(new ListItem("--Seleccione Cuenta--"));
            ddlCuenta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                String sql = "Select * from CuentaContable";

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();

                dr = cmd.ExecuteReader();
                ddlCuenta.DataSource = dr;
                ddlCuenta.DataTextField = "NombredelaAccion";
                ddlCuenta.DataValueField = "Id";
                ddlCuenta.DataBind();
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

        public void CargarTipoTransaccion()
        {
            ddlTipoTransaccion.Items.Clear();
            ddlTipoTransaccion.Items.Add(new ListItem("--Seleccione Forma de Transaccion--"));
            ddlTipoTransaccion.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                String sql = "Select * from TipoTransaccion";

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();

                dr = cmd.ExecuteReader();
                ddlTipoTransaccion.DataSource = dr;
                ddlTipoTransaccion.DataTextField = "Descripccion";
                ddlTipoTransaccion.DataValueField = "IdTipoTransaccion";
                ddlTipoTransaccion.DataBind();
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
            if (Textmonto.Text != "" && TextTipoCambio.Text!= "")
            {
                EntTransaccion tran = new EntTransaccion();
                tran.Monto = int.Parse(Textmonto.Text);
                tran.TipoCambio = double.Parse(TextTipoCambio.Text);
                tran.Glosa = TextGlosa.Text;
                tran.IdMoneda = int.Parse(ddlMoneda.Text);
                tran.IdFormaPago = int.Parse(ddlFormaPago.Text);
                tran.IdCuenta = int.Parse(ddlCuenta.Text);
                tran.IdTipoTransaccion = int.Parse(ddlTipoTransaccion.Text);
                if (Request.QueryString["Id"] != null)
                {
                    tran.Monto = Monto;
                    tran.TipoCambio = TipoCambio;
                    tran.Glosa = Glosa;
                    //ActualizaRegistros
                    tran.IdTransaccion = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegTransaccion.ActualizarTransaccion(tran) == 1)
                    {
                        
                        Response.Write("<script languaje =javascript>alert ('Registro de Transaccion ACTUALIZADO satisfactoriamente');</script>");
                        
                        Textmonto.Text = "";
                        TextTipoCambio.Text = "";
                        TextGlosa.Text = "";
                        

                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR la transaccion por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (NegTransaccion.InsertarTransacccion(tran)==1)
                    {
                        lblError.Text = "Registro de Marca guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        Textmonto.Text = "";
                    }
                }
            }
        }
    }
}