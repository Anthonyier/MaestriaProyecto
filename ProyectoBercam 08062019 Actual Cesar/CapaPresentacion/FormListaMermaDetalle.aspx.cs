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
    public partial class FormListaMermaDetalle : System.Web.UI.Page
    {
        int IdPersona = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRuta();
            }
        }

        protected void TextCli_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DtgListaMerma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string MermaId = e.CommandArgument.ToString();
                Response.Redirect("FormEditarMermas.aspx?Id=" + MermaId);
            }
        }
        public void CargarRuta()
        {
            CmRuta.Items.Clear();
            CmRuta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            CmRuta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                CmRuta.DataSource = dr; //cmd.ExecuteReader();    
                CmRuta.DataTextField = "Ruta";
                CmRuta.DataValueField = "Id_Ruta";
                CmRuta.DataBind();
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

        protected void TextBuscarMerma_TextChanged(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextBuscarMermaCliente.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdPersona = int.Parse(d["Id_Persona"].ToString());
                        CargarRuta();
                    }
                    catch (Exception er)
                    {
                    }
                }
            }
        }
     
    }
}