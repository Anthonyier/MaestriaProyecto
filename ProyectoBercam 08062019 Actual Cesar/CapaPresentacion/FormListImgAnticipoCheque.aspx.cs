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
    public partial class FormListImgAnticipoCheque : System.Web.UI.Page
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
        protected void DtgListaImgAnticiCheque_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarDocumento")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va ingresar A Descargar Anticipos ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntUsuario usuario = (EntUsuario)Session["Usuario"];
                EntPermisoAnticipos Anticip = NegPermisoAnticipos.BuscarPermiso(usuario.Id_Usuario);
                if (Anticip.VerAnticipo == 1)
                {
                    string AnticipoId = e.CommandArgument.ToString();
                    Response.Redirect("FormEditarFechaAnticipo.aspx?Id=" + AnticipoId);
                    //Response.Redirect("FrmImagenesAnticipo.aspx?Id=" + AnticipoId);
                }

            }
            if (e.CommandName == "Modificar")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va ingresar A Modificar Anticipos ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntUsuario usuario = (EntUsuario)Session["Usuario"];
                EntPermisoAnticipos Anticip = NegPermisoAnticipos.BuscarPermiso(usuario.Id_Usuario);
                if (Anticip.ModAnticipo == 1)
                {
                    string AnticipoId = e.CommandArgument.ToString();
                    Response.Redirect("FormModAnticipo.aspx?Id=" + AnticipoId);
                }

            }
            if (e.CommandName == "Visualizar")
            {
                string AnticipoId = e.CommandArgument.ToString();
                Response.Redirect("FormAnticiposImagenes.aspx?IdDetalle=" + AnticipoId);
            }
            if (e.CommandName == "Eliminar")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va eliminar un Anticipo ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                EntPermisoAnticipos Anticipos = NegPermisoAnticipos.BuscarPermiso(us.Id_Usuario);
                if (Anticipos.EliminarAnticipo == 1)
                {
                    string AnticipoId = e.CommandArgument.ToString();
                    int Idimagen = NegImagenesAnticipos.ObtenerImagAntic(Convert.ToInt32(AnticipoId));
                    NegImagenesAnticipos.DeshabilitarAnticipo(Convert.ToInt32(AnticipoId));
                    int IdDetallePago = NegImagenesAnticipos.ObtenerDetalleIdPago(Idimagen);
                    int IdPago = NegImagenesAnticipos.ObtenerIdPago(IdDetallePago);
                    NegImagenesAnticipos.DeshabilitarDetalleOrdenPago(IdDetallePago, IdPago);
                }

            }
        }
    }
}