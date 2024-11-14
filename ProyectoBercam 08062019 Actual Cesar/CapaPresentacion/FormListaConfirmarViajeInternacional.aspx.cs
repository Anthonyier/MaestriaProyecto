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
    public partial class FormListaConfirmarViajeInternacional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CargarMes();
                //CargarAño();
                //DdlAño.Text = DateTime.Now.Year.ToString();
            }
        }
        //public void CargarAño()
        //{
        //    DdlAño.Items.Clear();
        //    DdlAño.Items.Add(new ListItem("--Seleccione Año--", ""));
        //    DdlAño.AppendDataBoundItems = true;
        //    ClaseConexion Conexion = new ClaseConexion();
        //    SqlConnection cnx = Conexion.conectar();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        string sql = "Select * From Año";
        //        cmd.CommandText = sql;
        //        cmd.Connection = cnx;
        //        SqlDataReader dr = null;
        //        cnx.Open();
        //        dr = cmd.ExecuteReader();
        //        DdlAño.DataSource = dr;
        //        DdlAño.DataTextField = "Descripcion";
        //        DdlAño.DataValueField = "Descripcion";
        //        DdlAño.DataBind();
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //        cmd.Connection.Dispose();
        //    }
        //}
        //public void CargarMes()
        //{
        //    DdlMes.Items.Clear();
        //    DdlMes.Items.Add(new ListItem("--Seleccione el Mes--", ""));
        //    DdlMes.AppendDataBoundItems = true;
        //    ClaseConexion Conexion = new ClaseConexion();
        //    SqlConnection cnx = Conexion.conectar();
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        string sql = "SELECT * FROM Mes";
        //        cmd.CommandText = sql;
        //        cmd.Connection = cnx;
        //        SqlDataReader dr = null;
        //        cnx.Open();
        //        //cmd.Transaction = myTrans;
        //        dr = cmd.ExecuteReader();
        //        DdlMes.DataSource = dr; //cmd.ExecuteReader();    
        //        DdlMes.DataTextField = "Descripcion";
        //        DdlMes.DataValueField = "Id";
        //        DdlMes.DataBind();
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //        cmd.Connection.Dispose();
        //    }
        //}
        protected void DtgListarConfirmarInternacionalDescarga_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario usuario = (EntUsuario)Session["Usuario"];
            EntPermisoRutas Per = NegPermisoRutas.BuscarPermiso(usuario.Id_Usuario);
            if (e.CommandName == "ConfirmarFecha")
            {
                if (Per.ConfDescarga== 1)
                {
                    string IdDetalle = e.CommandArgument.ToString();
                 
                        Response.Redirect("FormConfirmarDescarga.aspx?Id=" + IdDetalle );
                }
            }
        }
    }
}