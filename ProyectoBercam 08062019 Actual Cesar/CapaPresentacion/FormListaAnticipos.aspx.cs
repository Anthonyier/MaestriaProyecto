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
    public partial class FormListaAnticipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmAño.Text = DateTime.Now.Year.ToString();
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
                cmAño.DataValueField = "Descripcion";
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
        protected void DtgListaAnticipo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Correo")
            {
                string PersonadId = e.CommandArgument.ToString();
                string Mensaje = "";
                string Camion = "";
                string Nombre = "";
                DateTime Fecha = Convert.ToDateTime("01/01/2010");
                SqlDataReader d = NegAnticipo.ReaderAnticipo(int.Parse(PersonadId));
                if (d.HasRows == true)
                {
                    while (d.Read())
                    {
                        try
                        {
                            Camion = d["Placa"].ToString();
                            Nombre = d["Nombre"].ToString();
                            Fecha = Convert.ToDateTime(d["FechaCarga"].ToString());
                            Mensaje = Mensaje + "Se Necesita Pagar los Anticipos De La Fecha: " + " " +Fecha + " " ;
                        }
                        catch (Exception er)
                        {

                        }
                    }
                    
                    NegAnticipo.Mensaje(Mensaje);
                    Response.Write("<script languaje =javascript>alert ('Mandado A revisar satisfactoriamente');</script>");
                }
            }
            if (e.CommandName == "AgregarDocumento")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va ingresar documentos ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntUsuario usuario = (EntUsuario)Session["Usuario"];
                EntPermisoAnticipos Anticipi = NegPermisoAnticipos.BuscarPermiso(usuario.Id_Usuario);
                if (Anticipi.PagarAnticipo == 1)
                {
                    string AnticipoId = e.CommandArgument.ToString();
                    Response.Redirect("FrmImagenesAnticipo.aspx?Id=" + AnticipoId);
                }
            }
            //if (e.CommandName == "PagoSinFactura")
            //{
            //    EntUsuario us = (EntUsuario)Session["Usuario"];
            //    EntBitacora bit = new EntBitacora();
            //    bit.Usuario = us.Nombre + "" + us.Apellidos;
            //    bit.Accion = "El usuario va ingresar documentos ";
            //    bit.IdUsuario = us.Id_Usuario;
            //    int bi = NegBitacora.GuardarBitacora(bit);
            //    EntUsuario usuario = (EntUsuario)Session["Usuario"];
            //    EntPermisoAnticipos Anticipi = NegPermisoAnticipos.BuscarPermiso(usuario.Id_Usuario);
            //    if (Anticipi.PagarAnticipo == 1)
            //    {
            //        string AnticipoId = e.CommandArgument.ToString();
            //        Response.Redirect("FormPagarAnticipoSinFactura.aspx?Id=" + AnticipoId);
            //    }
            //}
        }

        protected void cmAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}