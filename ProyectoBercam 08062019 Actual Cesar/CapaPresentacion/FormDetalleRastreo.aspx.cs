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
    public partial class FormDetalleRastreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                if (Request.QueryString["Id"] != null)
                {
                    int IdRastreo = Convert.ToInt32(Request.QueryString["Id"]);
                    EntDetalleRastreo Rast = new EntDetalleRastreo();
                    EntCamiones Cam = new EntCamiones();
                    Rast = NegDetalleRastreo .BuscarRastreo(IdRastreo);
                    Cam = NegCamiones.BuscarCamiones(Rast.IdCamion);
                    TextoPlacaRastreos.Text = Cam.Placa;
                    TextMontoCobrar.Text = Convert.ToString(Rast.MontoCobrar) ;
                    TextMontoPagar.Text = Convert.ToString(Rast.MontoPagar);
                    DdlAño.Text = Convert.ToString(Rast.IdAño);
                    DdlMes.Text = Convert.ToString(Rast.IdMes);
                }
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosServicios Per = NegPermisosServicios.BuscarPermiso(usuario.Id_Usuario);
            if (Per.GuardarRastreo != 1)
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
            if (TextMontoPagar.Text != "" && TextMontoCobrar.Text != "")
            {
                int IdCamion = 0;
                SqlDataReader d = NegCamiones.BuscarCamion(TextoPlacaRastreos.Text);
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
                EntDetalleRastreo Edr = new EntDetalleRastreo ();
                Edr.IdCamion = IdCamion;
                Edr.MontoPagar  = Convert.ToDouble(TextMontoPagar.Text);
                Edr.MontoCobrar  = Convert.ToDouble (TextMontoCobrar.Text);
                Edr.MontoCinabar = Edr.MontoCobrar-Edr.MontoPagar ;
                Edr.IdAño = int.Parse(DdlAño.Text);
                Edr.IdMes= Convert.ToInt32(DdlMes.Text);
                if (Request.QueryString["Id"] != null)
                {
                    Edr.Id = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegDetalleRastreo.Actualizar(Edr) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Registro de Rastreo ACTUALIZADO satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Rastreo ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");

                    }
                    //else
                    //{
                    //    lblError.Text = "No se pudo ACTUALIZAR el Camion Guia por algun motivo, Verifique e intente nuevamente";
                    //    lblError.Visible = true;
                    //}
                }
                else
                {
                    if (NegDetalleRastreo.InsertarRastreo(Edr) == 1)
                    {
                        Response.Write("<script languaje =javascript>alert ('Registro de Detalle de Rastreo satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextoPlacaRastreos.Text = "";
                        TextMontoCobrar.Text = "";
                        DdlAño.Text = "";
                        TextMontoPagar.Text = "";
                        DdlMes.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Servicio por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
            }
        }

        protected void BtnTitular_Click(object sender, EventArgs e)
        {
            lblTitular.Text = "*";
            if (TextoPlacaRastreos.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarPlacaTitular(TextoPlacaRastreos.Text);
                if (d.HasRows == true)
                {
                    if (d!= null)
                    {
                        try
                        {
                            TxtTitular.Text = d["titular"].ToString();
                        }
                        catch (Exception er)
                        {
                            lblTitular.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                            
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        lblTitular .Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                       
                    }
                }
                else
                {
                    lblTitular.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                   
                }

            }
            else
            {
                lblTitular.Text = "Debe introducir el CI del Propietario que desea buscar";
            }

        }

        protected void BtnConjunto_Click(object sender, EventArgs e)
        {
            int IdAño = int.Parse(DdlAño.Text);
            int IdMes = Convert.ToInt32(DdlMes.Text);
            if (NegDetalleRastreo.GuardarGrupoRastreo(IdMes, IdAño) == 1)
            {
                Response.Write("<script languaje =javascript>alert ('Registro de Detalle de Rastreo satisfactoriamente');</script>");
            }
        }
    }
}