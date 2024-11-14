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
    public partial class FormListaAsegAlcohol : System.Web.UI.Page
    {
        //static ClaseConexion Conexion=new ClaseConexion();
        //SqlConnection cnx = Conexion.conectar();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
            }
            if (Request.QueryString["Id"] != null)
            {

            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando Asegurar Las Conciliaciones A Pagar De Alcohol";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosConciliaciones Persona = NegPermisosConciliaciones.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.AsegAlc != 1)
            {

                GridView1.Visible = false;
                GridView1.Visible = false;
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
        public void CargarMes()
        {
            cmMes.Items.Clear();
            cmMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
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
                cmMes.DataValueField = "Id";
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
        protected void DtgListaAprobarAlcohol_RowCommand(object sender,GridViewCommandEventArgs e) {
            if (e.CommandName == "Imprimir")
            {
                string sPersonaId = e.CommandArgument.ToString();
                Response.Redirect("FormRepConCorporacionFlet.aspx?Id=" + sPersonaId);
            }
            if (e.CommandName == "NuevoFormato")
            {
                string sPersonaId = e.CommandArgument.ToString();
                Response.Redirect("FormRepConcRefPagar2023.aspx?Id=" + sPersonaId);
            }
            if (e.CommandName == "Revisar")
            {
                string PersonadId = e.CommandArgument.ToString();
                string Mensaje = "La Conciliacion: " + " " + PersonadId + "Necesita ser revisada";
                NegConciliacionPorPagar.Revisar(int.Parse(PersonadId));
                NegConciliacionPorPagar.Mensaje(Mensaje);
                Response.Write("<script languaje =javascript>alert ('Mandado A revisar satisfactoriamente');</script>");
            }
        }
    }
}