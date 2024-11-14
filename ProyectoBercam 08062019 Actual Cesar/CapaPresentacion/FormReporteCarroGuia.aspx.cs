using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FormReporteCarroGuia : System.Web.UI.Page
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
                bit.Accion = "El usuario esta intentando Ver la Lista De Conciliaciones De Carros Guias";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisosCarroGuias Persona = NegPermisosCarroGuia.BuscarPermiso(usuario.Id_Usuario);

            if (Persona.ListConcCarrroGuia!= 1)
            {

                ButtonBus.Visible = false;
                ButtonBus.Visible = false;
            }
        }

        protected void ButtonBus_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameter = new ReportParameter[2];
            parameter[0] = new ReportParameter("IdPeriodo", cmPeriodo.Text);
            parameter[1] = new ReportParameter("IdAño", cmAño.Text);
            ReportViewer1.LocalReport.SetParameters(parameter);
            ReportViewer1.LocalReport.Refresh();
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

        protected void ButtonSolicitado_Click(object sender, EventArgs e)
        {
            //NegConciliacionCarroGuia.Aprobar(Convert.ToInt32(cmPeriodo.Text),Convert.ToInt32(cmAño.Text));
            //NegDetalleCarroGuia.AprobarCarroGuia(Convert.ToInt32(cmPeriodo.Text), Convert.ToInt32(cmAño.Text));
            //Response.Write("<script languaje =javascript>alert ('El Carro Guia Ha sido Aprobado');</script>");
        }
    }
}