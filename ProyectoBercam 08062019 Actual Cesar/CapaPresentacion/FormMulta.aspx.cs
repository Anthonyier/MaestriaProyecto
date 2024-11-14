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
    public partial class FormMulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCliente();
                if (Request.QueryString["id"] != null)
                {
                    int IdMulta = Convert.ToInt32(Request.QueryString["id"]);
                    EntMulta Mul = new EntMulta();
                    Mul = NegMulta.BuscarMulta(IdMulta);
                    txtConcep.Text = Mul.Concepto;
                    TextMulta.Text = Convert.ToString(Mul.Multa);
                    DdlMulClientes.Text = Convert.ToString(Mul.IdCliente);
                }
            }
              EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.ListCobrRef != 1)
            {
                BtnGuardar.Visible = false;
                BtnGuardar.Enabled = false;
            }
        }

        public void CargarCliente()
        {
            DdlMulClientes.Items.Clear();
            DdlMulClientes.Items.Add(new ListItem("--Selecciona Cliente--", ""));
            DdlMulClientes.AppendDataBoundItems = true;
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
                DdlMulClientes.DataSource = dr; //cmd.ExecuteReader();    
                DdlMulClientes.DataTextField = "CLIENTE";
                DdlMulClientes.DataValueField = "Id_Persona";
                DdlMulClientes.DataBind();
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
            if (TextMulta.Text != "" && txtConcep.Text != "" )
            {
                EntMulta Mul = new EntMulta();
                Mul.Concepto = txtConcep.Text;
                Mul.Multa = double.Parse(TextMulta.Text);
                Mul.IdCliente = Convert.ToInt32(DdlMulClientes.Text);
                if (Request.QueryString["Id"] != null)
                {
                    Mul.id = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegMulta.ActualizarMulta(Mul) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        //lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Multa ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        txtConcep.Text = "";
                        TextMulta.Text = "";
                        
                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR la Multa por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if(NegMulta.InsertarMulta(Mul)==1)
                    {
                        Response.Write("<script languaje =javascript>alert ('Registro de Multa Guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        txtConcep.Text = "";
                        TextMulta.Text = "";
                       
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar la Multa por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }

            }
        }
    }
}