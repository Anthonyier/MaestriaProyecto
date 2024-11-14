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
    public partial class FormDetalleTelefono : System.Web.UI.Page
    {
        int Libre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                if (Request.QueryString["Id"] != null)
                {
                    int IdTelefono = Convert.ToInt32(Request.QueryString["Id"]);
                    EntDetalleTelefono Telf = new EntDetalleTelefono();
                    EntCamiones Cam = new EntCamiones();
                    Telf = NegDetalleTelefono.BuscarTodo(IdTelefono);
                    if (Telf.IdCamion == 0)
                    {
                        TextBoxPlacaTelf.Text = Convert.ToString(0);
                        TextPropietario.Visible = true;
                        TextPropietario.Text = Telf.Personal;

                    }
                    else 
                    {
                        Cam = NegCamiones.BuscarCamiones(Telf.IdCamion);
                        TextBoxPlacaTelf.Text = Cam.Placa;
                    }
                   
                    TextNumero.Text = Telf.Numero;
                    TextMontoCobrar.Text = Convert.ToString(Telf.MontoCobrar);
                    TextCredito.Text = Convert.ToString( Telf.Credito);
                    if (Telf.Libre==1) 
                    {
                        chkNo.Checked = true;
                    
                    }
                    else
                    {
                        chkSi.Checked = true;
                    }
                    DdlAño.Text= Convert.ToString(Telf.IdAño);
                    DdlMes.Text = Convert.ToString(Telf.IdMes);
                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosServicios Per = NegPermisosServicios.BuscarPermiso(usuario.Id_Usuario);
            if (Per.GuardarTelefono != 1)
            {
                BtnGuardar.Visible = false;
                BtnConjunto.Visible = false;
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

        public void CargarMes()
        {
            DdlMes.Items.Clear();
            DdlMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
            DdlMes.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Mes";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlMes.DataSource = dr; //cmd.ExecuteReader();    
                DdlMes.DataTextField = "Descripcion";
                DdlMes.DataValueField = "Id";
                DdlMes.DataBind();
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
            if (TextNumero.Text !="" && TextMontoCobrar.Text != "")
            {
                int IdCamion = 0;
                SqlDataReader d = NegCamiones.BuscarCamion(TextBoxPlacaTelf.Text);
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
                EntDetalleTelefono  Enf = new EntDetalleTelefono();
                Enf.IdCamion = IdCamion;
                Enf.Numero = TextNumero.Text;
                Enf.Personal = TextPropietario.Text;
                if (chkSi.Checked)
                {
                    Libre = 0;
                }
                if (chkNo.Checked)
                {
                    Libre = 1;
                }
                Enf.Libre = Libre;
                Enf.MontoCobrar = Convert.ToDouble(TextMontoCobrar.Text);
                Enf.IdAño = int.Parse(DdlAño.Text);
                Enf.IdMes = Convert.ToInt32(DdlMes.Text);
                Enf.Credito = double.Parse(TextCredito.Text);
                if (Request.QueryString["Id"] != null)
                {
                    Enf.Id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Guia.Id_Guia = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegDetalleTelefono.Actualizar(Enf) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Registro de Telefono Actualizado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Telefono Actualizado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");

                    }
                    else
                    {
                        lblError.Text = "No se pudo Actualizar el Telefono por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (NegDetalleTelefono .GuardarTelefono(Enf) == 1)
                    {
                        Response.Write("<script languaje =javascript>alert ('Registro de Detalle de Rastreo satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextBoxPlacaTelf.Text = "";
                        TextMontoCobrar.Text = "";
                        TextPropietario.Text = "";
                        chkCamion.Checked = false;
                        chkSi.Checked = false;
                        chkNo.Checked = false;
                        TextNumero.Text = "";
                        DdlAño.Text = "";
                        DdlMes.Text = "";
                        TextCredito.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Servicio por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }

        protected void chkSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSi.Checked)
            {
               
                chkNo.Checked = false;
            }
        }

        protected void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNo.Checked)
            {
             
                chkSi.Checked = false;
            }
        }

        protected void chkCamion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCamion.Checked)
            {
                TextPropietario.Visible = true;
            }
            else
            {
                TextPropietario.Visible = false;
            }
        }

        protected void BtnConjunto_Click(object sender, EventArgs e)
        {
             int IdAño = int.Parse(DdlAño.Text);
             int IdMes = Convert.ToInt32(DdlMes.Text);
             if (NegDetalleTelefono.GuardarGrupoTelefono(IdMes, IdAño)==1)
             {
                 Response.Write("<script languaje =javascript>alert ('Registro de Detalle de Telefono satisfactoriamente');</script>");
             }
        }
    }
}