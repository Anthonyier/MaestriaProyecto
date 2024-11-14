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
    public partial class FormListaRastreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
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
                string sql = "SELECT * FROM Año";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmAño.DataSource = dr; //cmd.ExecuteReader();    
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

        protected void BtnLibre_Click(object sender, EventArgs e)
        {
            GridViewTelefonos.Visible = false;
            GridLibre.Visible = true;
            GridOcupado.Visible = false;
            GridView4.Visible = false;
        }

        protected void BtnOcupado_Click(object sender, EventArgs e)
        {
            GridViewTelefonos.Visible = false;
            GridLibre.Visible = false;
            GridOcupado.Visible = true;
            GridView4.Visible = false;
        }

        protected void BtnNormal_Click(object sender, EventArgs e)
        {
            GridViewTelefonos.Visible = true;
            GridLibre.Visible = false;
            GridOcupado.Visible = false;
            GridView4.Visible = false;
        }
        protected void DtgLista_telefono_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.IdUsuario = us.Id_Usuario;

            if (e.CommandName == "EditarTelefono")
            {
                bit.Accion = "El Usuario va a Modificar Telefono ";

                int bi = NegBitacora.GuardarBitacora(bit);

                EntPermisosServicios Permiso = NegPermisosServicios.BuscarPermiso(us.Id_Usuario);
                if (Permiso.ModificarTelefono == 1)
                {
                    string telefonoId = e.CommandArgument.ToString();
                    Response.Redirect("FormDetalleTelefono.aspx?Id=" + telefonoId);
                }
              
            }
            if (e.CommandName == "EliminarTelefono")
            {
                bit.Accion = "El Usuario va a Eliminar Telefono";

                int bi = NegBitacora.GuardarBitacora(bit);

                string telefonoId = e.CommandArgument.ToString();
                NegDetalleTelefono.EliminarTelefono(int.Parse(telefonoId));
            }
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridOcupado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnGeneral_Click(object sender, EventArgs e)
        {
            GridViewTelefonos.Visible = false;
            GridLibre.Visible = false;
            GridOcupado.Visible = false;
            GridView4.Visible = true;
        }

        protected void GridViewTelefonos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}