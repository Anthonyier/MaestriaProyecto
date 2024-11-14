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
    public partial class FormTransAdelAnt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAño();
                CargarMes();
                cmAño.Text = DateTime.Now.Year.ToString();
            }
            EntUsuario Usuario = (EntUsuario)Session["Usuario"];
            if(Usuario.Id_Usuario == 1002 || Usuario.Id_Usuario==1)
            {

                Gridview1.Visible = true;
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

        protected void DtgListaTransAdelAntic_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "TransformarAnticipo")
            {
                string DetalleId = e.CommandArgument.ToString();
                int IdCamion=NegAsignacionRuta.EncontrarIdCamion(Convert.ToInt32(DetalleId));
                EntCamiones Cam = NegCamiones.BuscarCamiones(IdCamion);
                EntPersona Pers = NegPersona.BuscarPersonaCI(Cam.IdTitBanco);
                EntAdelantoDePago AdelPag = new EntAdelantoDePago();
                AdelPag.Monto = NegAsignacionRuta.EncontrarAnticipo(Convert.ToInt32(DetalleId));
                AdelPag.Estado = 1;
                AdelPag.FechaAdelanto = NegAsignacionRuta.EncontrarFechaAnticipo(Convert.ToInt32(DetalleId));
                AdelPag.FechaPago = NegAsignacionRuta.EncontrarFechaAnticipo(Convert.ToInt32(DetalleId));
                AdelPag.IdPersona = Pers.Id_Persona;
                int idAdelanto=NegAdelantoDePago.GuardarAdelantoDEPago(AdelPag);
                EntImagenesAdelantoDePagos ImgAdelPag = new  EntImagenesAdelantoDePagos();
                EntImagenesAnticipos AntImg = NegImagenesAnticipos.TransImagen(Convert.ToInt32(DetalleId));
                ImgAdelPag.Imagen = AntImg.Imagen;
                ImgAdelPag.Estado = 1;
                ImgAdelPag.Nombre = AntImg.NombreDoc;
                ImgAdelPag.Ext = AntImg.Ext;
                ImgAdelPag.IdAdelanto = idAdelanto;
                int Adel=NegImagenesAdelantoDepagos.TransImgAdel(ImgAdelPag);
                int Anticip=NegImagenesAnticipos.ObtenerImagAntic(Convert.ToInt32(DetalleId));
                NegImagenesAnticipos.ModificarOrdenesPago(Anticip,Adel);
                NegImagenesAnticipos.EliminarAnticipoRecp(Convert.ToInt32(DetalleId));
                NegImagenesAnticipos.EliminarImagenAntic(Convert.ToInt32(DetalleId));
                Response.Write("<script languaje =javascript>alert ('Transformacion Exitosa');</script>");
                Response.Redirect("FormTransAdelAnt.aspx");

            }
        }

       
    }
}