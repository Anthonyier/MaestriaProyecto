using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FormListaConcDapInter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmdAño.Text = DateTime.Now.Year.ToString();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando ver la Lista de Conciliaciones De Corporacion";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.ListCobrCorp != 1)
            {

                GridView1.Visible = false;
                GridView1.Visible = false;
            }
        }
        public void CargarAño()
        {
            cmdAño.Items.Clear();
            cmdAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmdAño.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "Select * From Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cmdAño.DataSource = dr;
                cmdAño.DataTextField = "Descripcion";
                cmdAño.DataValueField = "Id";
                cmdAño.DataBind();
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
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Periodo--", ""));
            cmMes.AppendDataBoundItems = true;
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
                cmMes.DataSource = dr; //cmd.ExecuteReader();    
                cmMes.DataTextField = "Descripcion";
                cmMes.DataValueField = "id";
                cmMes.DataBind();
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
        protected void DtgListaConcDapInter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Imprimir")
            {
                string sPersonaId = e.CommandArgument.ToString();
                Response.Redirect("FormRepConCorp.aspx?Id=" + sPersonaId);
            }
            if (e.CommandName == "Aprobar")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va a aprobar una Conciliacion de Coorporacion";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(us.Id_Usuario);
                if (Persona.AprobCobrCorp   == 1)
                {
                    string ConcId = e.CommandArgument.ToString();
                    if (NegConciliacionPorCobrar.EstaAprobado(Convert.ToInt32(ConcId)) == 1)
                    {

                        NegConciliacionPorCobrar.Aprobar(Convert.ToInt32(ConcId));
                        Response.Write("<script languaje =javascript>alert ('Se Logro Aprobar La Conciliacion De Aceite ');</script>");
                    }
                    else
                    {
                        Response.Write("<script languaje =javascript>alert ('Esta Conciliacion NO SE PUEDE APROBAR porque esta Conciliacion ya fue Aprobada');</script>");
                    }
                }
            }
        }
    }
}