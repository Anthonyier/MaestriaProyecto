using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormListaConciliacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarPeriodo();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando ver la Lista de Conciliaciones De Refinacion";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.ListCobrRef != 1)
            {

                GridViewConciliacion.Visible = false;
                GridViewConciliacion.Visible = false;
            }
        }
        public void CargarAño()
        {
            cmAño.Items.Clear();
            cmAño.Items.Add(new ListItem("--Seleccione Año--", ""));
            cmAño.AppendDataBoundItems = true;
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
                cmAño.DataSource = dr;
                cmAño.DataTextField = "Descripcion";
                cmAño.DataValueField = "Id";
                cmAño.DataBind();
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
            cmPeriodo.Items.Clear();
            cmPeriodo.Items.Add(new ListItem("--Seleccione el Periodo--", ""));
            cmPeriodo.AppendDataBoundItems = true;
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
                cmPeriodo.DataSource = dr; //cmd.ExecuteReader();    
                cmPeriodo.DataTextField = "Quincena";
                cmPeriodo.DataValueField = "id";
                cmPeriodo.DataBind();
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

        protected void DtgListaConciliacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Imprimir")
            {
                string sPersonaId = e.CommandArgument.ToString();
                Response.Redirect("FormRepConciliacion.aspx?Id=" + sPersonaId);
            }
            if (e.CommandName == "Aprobar")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va a aprobar una Conciliacion de Refinacion";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(us.Id_Usuario);
                if (Persona.AprobCobrAcei == 1)
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