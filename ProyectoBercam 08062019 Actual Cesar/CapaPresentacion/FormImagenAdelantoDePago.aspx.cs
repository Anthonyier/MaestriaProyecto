using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using System.IO;
using CapaNegocios;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FormImagenAdelantoDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                 EntImagenesAdelantoDePagos ObjImagen = new EntImagenesAdelantoDePagos();
                ObjImagen = NegImagenesAdelantoDepagos .ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    //TextPagado.Text = ObjImagen.Nombre;
                }
                CargarCuentaBancaria();
            }
        }
        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFechaAdel.SelectedDate != null)
            {
                TextFecha.Text = CalendarFechaAdel.SelectedDate.ToString("d");
                CalendarFechaAdel.Visible = false;
            }

        }
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaAdel.Visible)
            {
                CalendarFechaAdel.Visible = false;
            }
            else
            {
                CalendarFechaAdel.Visible = true;
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenesAdelantoDePagos DocPagadas = new EntImagenesAdelantoDePagos();
            int IdPer = NegAdelantoDePago.IdPersona(Convert.ToInt32(Request.QueryString["Id"]));
            int MaestProv = NegMaestroProveedor.EncontrarIdProveedor(IdPer);
            int IdPasivo = NegMaestroProveedor.EncontrarAnticipo(MaestProv);
            //string Nombre = Pers.Nombres + ' ' + Pers.Apellidos;
            double MontoAdelanto = NegAdelantoDePago.EncontrarMonto(Convert.ToInt32(Request.QueryString["Id"]));
            int IdAdelanto=NegAdelantoDePago.ObtenerImagen(Convert.ToInt32(Request.QueryString["Id"]));
            if (IdAdelanto == 0)
            {

                if (this.FileUpPagado.HasFile)
                {
                    using (BinaryReader reader = new BinaryReader(this.FileUpPagado.PostedFile.InputStream))
                    {
                        byte[] image = reader.ReadBytes(FileUpPagado.PostedFile.ContentLength);
                        DocPagadas.Imagen = image;
                        FileInfo Fi = new FileInfo(FileUpPagado.FileName);
                        DocPagadas.Nombre = Fi.Name;
                        DocPagadas.Ext = Fi.Extension;
                        DocPagadas.IdAdelanto = Convert.ToInt32(Request.QueryString["Id"]);
                    }
                    if (DocPagadas.Imagen != null && MaestProv != 0)
                    {
                        //int IdImagPago = NegImagenesAdelantoDepagos.GuardarImagens(DocPagadas);
                        //if (IdImagPago != 0)
                        //{
                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        int IdUsuario = us.Id_Usuario;
                        int idTipoPago = 301;
                        EntMaestroProveedor MaPr = new EntMaestroProveedor();
                        MaPr.FechaAntcipo = DateTime.Parse(TextFecha.Text);
                        MaPr.IdPers = IdPer;
                        MaPr.IdUsuario = IdUsuario;
                        MaPr.MontoAnticipo = MontoAdelanto;
                        MaPr.IdAnticipo = 0;
                        MaPr.IdTipoPago = idTipoPago;
                        int modPago = 103;
                        string modalidad = "TRANSFERENCIA ELECTRONICA";
                        int IdCuenta = Convert.ToInt32(DdlCuentaBancaria.Text);
                        bool Ver = NegAdelantoDePago.Maestroproveedor(DateTime.Parse(TextFecha.Text), IdPer, IdUsuario, MontoAdelanto, DocPagadas, idTipoPago, IdPasivo,modPago,modalidad,IdCuenta);
                        if (Ver == true)
                        {
                            NegAdelantoDePago.Estado(DocPagadas.IdAdelanto);
                            NegAdelantoDePago.FechaPago(DocPagadas.IdAdelanto, DateTime.Parse(TextFecha.Text));
                            lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Registro de Adelanto de Pago guardado satisfactoriamente');</script>");
                            Response.Redirect("FormListaAdelantoDePagos.aspx");
                        }

                     //}
                        else
                        {
                            lblError.Text = "No se pudo Insertar la Imagen de Adelantos por algun motivo, Verifique e intente nuevamente";
                            lblError.Visible = true;

                        }
                    }
                    else
                    {
                        lblError.Text = "No se Encontro el maestro proveedor, por favor comuniquese con sistemas";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    DocPagadas.Imagen = null;
                }
            }
       }
        public void CargarCuentaBancaria()
        {
            DdlCuentaBancaria.Items.Clear();
            DdlCuentaBancaria.Items.Add(new ListItem("--Seleccione Cuenta--", ""));
            DdlCuentaBancaria.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {

                cmd.Connection = cnx;
                cmd = new SqlCommand("ProcEncontrarCuentaPago", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlCuentaBancaria.DataSource = dr; //cmd.ExecuteReader();    
                DdlCuentaBancaria.DataTextField = "NombreCuenta";
                DdlCuentaBancaria.DataValueField = "idCuentaContable";
                DdlCuentaBancaria.DataBind();
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
    }
}