﻿using System;
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
    public partial class FrmImagenesAnticipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesAnticipos ObjImagen = new EntImagenesAnticipos();
                ObjImagen=NegImagenesAnticipos.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    TextAnticip.Text = ObjImagen.NombreDoc;
                }
                CargarCuentaBancaria();
            }

        }
        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFechaAntc.SelectedDate != null)
            {
                TextFecha.Text = CalendarFechaAntc.SelectedDate.ToString("d");
                CalendarFechaAntc.Visible = false;
            }

        }
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaAntc.Visible)
            {
                CalendarFechaAntc.Visible = false;
            }
            else
            {
                CalendarFechaAntc.Visible = true;
            }
        }
        protected void BtnAnticip_Click(object sender, EventArgs e)
        {
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntImagenesAnticipos Img = new EntImagenesAnticipos ();
            Img = NegImagenesAnticipos.Download(Convert.ToInt32(Request.QueryString["Id"]));
            if (Img == null)
            {
                lblError.Text = "No se pudo Descargar La Imagen";
                lblError.Visible = true;
                return;
            }
            byte[] Document = (byte[])Img.Imagen;
            Response.ClearContent();
            Response.ContentType = "application/octetstream";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.NombreDoc));
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenesAnticipos DocAnticip = new EntImagenesAnticipos();
            int DetalleId = Convert.ToInt32(Request.QueryString["Id"]);
            int IdCamion = NegAsignacionRuta.EncontrarIdCamion(Convert.ToInt32(DetalleId));
            EntCamiones Cam = NegCamiones.BuscarCamiones(IdCamion);
            EntPersona Pers = NegPersona.BuscarPersonaCI(Cam.IdTitBanco);
            int IdPer = Pers.Id_Persona;
            int MaestProv = NegMaestroProveedor.EncontrarIdProveedor(IdPer);
            int IdPasivo = NegMaestroProveedor.EncontrarAnticipo(MaestProv);
            //string Nombre = Pers.Nombres + ' ' + Pers.Apellidos;
            double MontoAnticipo = NegAsignacionRuta.EncontrarAnticipo(DetalleId);
            int IdImgAnticipo = NegImagenesAnticipos.ObtenerImagAntic(DetalleId);
            if (IdImgAnticipo == 0)
            {

                if (this.FileUpAnticip.HasFile)
                {
                    using (BinaryReader reader = new BinaryReader(this.FileUpAnticip.PostedFile.InputStream))
                    {
                        byte[] image = reader.ReadBytes(FileUpAnticip.PostedFile.ContentLength);
                        DocAnticip.Imagen = image;
                        FileInfo Fi = new FileInfo(FileUpAnticip.FileName);
                        DocAnticip.NombreDoc = Fi.Name;
                        DocAnticip.Ext = Fi.Extension;
                        DocAnticip.IdDetalle = Convert.ToInt32(Request.QueryString["Id"]);
                        DocAnticip.FechaAnticipo = Convert.ToDateTime(TextFecha.Text);
                    }
                    if (DocAnticip.Imagen != null && MaestProv != 0)
                    {
                        //int IdAnticip = NegImagenesAnticipos.InsertarImagen(DocAnticip);
                        //if (IdAnticip != 0)
                        //{

                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        int IdUsuario = us.Id_Usuario;
                        int idTipoPago = 301;
                        EntMaestroProveedor MaPr = new EntMaestroProveedor();
                        MaPr.FechaAntcipo = DocAnticip.FechaAnticipo;
                        MaPr.IdPers = IdPer;
                        MaPr.IdUsuario = IdUsuario;
                        MaPr.MontoAnticipo = MontoAnticipo;
                        MaPr.IdAnticipo = 0;
                        MaPr.IdTipoPago = idTipoPago;
                        int modPago = 103;
                        string modalidad = "TRANSFERENCIA ELECTRONICA";
                        int IdCuenta = Convert.ToInt32(DdlCuentaBancaria.Text); 
                        bool Ver = NegImagenesAnticipos.Maestroproveedor(DocAnticip.FechaAnticipo, IdPer, IdUsuario, MontoAnticipo, DocAnticip, idTipoPago, IdPasivo,modPago,modalidad,IdCuenta);
                        if (Ver == true)
                        {
                            NegImagenesAnticipos.EnvioConfirmado(Convert.ToInt32(Request.QueryString["Id"]), DocAnticip.FechaAnticipo);
                            lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Registro de Anticipos guardado satisfactoriamente');</script>");
                            Response.Redirect("FormListaAnticipos.aspx");

                        }

                    //}
                        else
                        {
                            lblError.Text = "No se pudo Insertar la Imagen por ya sea problemas con la imagen y/o el maestro proveedor no existe";
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
                    DocAnticip.Imagen = null;
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