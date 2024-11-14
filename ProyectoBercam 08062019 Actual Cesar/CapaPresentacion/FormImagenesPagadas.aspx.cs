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
    public partial class FormImagenesPagadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesPagadas  ObjImagen = new EntImagenesPagadas();
                ObjImagen = NegImgPagadas.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    //TextPagado.Text = ObjImagen.Nombre;
                }
                CargarCuentaBancaria();
            }
        }

        //protected void BtnPagado_Click(object sender, EventArgs e)
        //{
        //    int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
        //    EntImagenesPagadas Img = new EntImagenesPagadas();
        //    Img = NegImgPagadas.Download(Convert.ToInt32(Request.QueryString["Id"]));
        //    if (Img == null)
        //    {
        //        lblError.Text = "No se pudo Descargar La Imagen";
        //        lblError.Visible = true;
        //        return;
        //    }
        //    byte[] Document = (byte[])Img.Imagen;
        //    Response.ClearContent();
        //    Response.ContentType = "application/octetstream";
        //    Response.AddHeader("Content-Disposition", string.Format("attachment;filenames={0}", Img.Nombre));
        //    Response.AddHeader("Content-Length", Document.Length.ToString());
        //    Response.BinaryWrite(Document);
        //    Response.Flush();
        //    Response.Close();
        //}
        protected void Calendar_FechaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarFechaPago.SelectedDate != null)
            {
                TextFecha.Text = CalendarFechaPago.SelectedDate.ToString("d");
                CalendarFechaPago.Visible = false;
            }

        }
        protected void imgCalendarFecha_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarFechaPago.Visible)
            {
                CalendarFechaPago.Visible = false;
            }
            else
            {
                CalendarFechaPago.Visible = true;
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenesPagadas DocPagadas = new EntImagenesPagadas();
            EntConciliacionPorPagar ConcPagar = new EntConciliacionPorPagar();
            ConcPagar = NegConciliacionPorPagar.BuscarConcPagar(Convert.ToInt32(Request.QueryString["Id"]));
            int IdPer = ConcPagar.IdTitular;
            int MaestProv = NegMaestroProveedor.EncontrarIdProveedor(ConcPagar.IdTitular);
            int IdPasivo = NegMaestroProveedor.EncontrarAnticipo(MaestProv);
            double MontoPorPagar = ConcPagar.PorPagar;
            int IdFactura = ConcPagar.IdFactura;
            int IdEstado = NegImgPagadas.Verificar(Convert.ToInt32(Request.QueryString["Id"]));
            bool Ver = false;
            if (IdEstado == 0)
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
                        DocPagadas.IdConciliacion = Convert.ToInt32(Request.QueryString["Id"]);
                        DocPagadas.FechaPago = Convert.ToDateTime(TextFecha.Text);
                    }
                    if (DocPagadas.Imagen != null)
                    {
                        //int IdImgPga = NegImgPagadas.InsertarImagen(DocPagadas);
                        //if (IdImgPga != 0)
                        //{


                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        int IdUsuario = us.Id_Usuario;
                        int idTipoPago = 304;
                        EntMaestroProveedor MaPr = new EntMaestroProveedor();
                        MaPr.FechaAntcipo = DateTime.Parse(TextFecha.Text);
                        MaPr.IdPers = ConcPagar.IdTitular;
                        MaPr.IdUsuario = IdUsuario;
                        MaPr.MontoAnticipo = MontoPorPagar;
                        MaPr.IdAnticipo = 0;
                        MaPr.IdTipoPago = idTipoPago;
                        int modPago = 103;
                        string modalidad = "TRANSFERENCIA ELECTRONICA";
                        int IdCuenta = Convert.ToInt32(DdlCuentaBancaria.Text); 
                        if (IdFactura == -1)
                        {
                            int IdAdelantoRec = NegAdelantoDePago.NEncontrarAdelantoPagoRecibo(DocPagadas.IdConciliacion);
                            int IdDescuentoRec = NegAdelanto.NEncontrarDescuentoRecibo(DocPagadas.IdConciliacion);
                            Ver = NegImgPagadas.MaestroProveedorRecibo(DateTime.Parse(TextFecha.Text), IdPer, IdUsuario, MontoPorPagar, DocPagadas, idTipoPago, IdPasivo, IdAdelantoRec, IdDescuentoRec,modPago,modalidad,IdCuenta);
                        }
                        else
                        {
                            int IdAdelanto = NegAdelantoDePago.NEncontrarAdelantoDePago(IdFactura);
                            int IdDescuento = NegAdelanto.NEncontrarDescuento(IdFactura);
                            Ver = NegImgPagadas.MaestroProveedor(DateTime.Parse(TextFecha.Text), IdPer, IdUsuario, MontoPorPagar, DocPagadas, idTipoPago, IdPasivo, IdAdelanto, IdDescuento, IdFactura,modPago,modalidad,IdCuenta);
                        }
                        
                        if (Ver == true)
                        {
                            NegConciliacionPorPagar.Pagado(int.Parse(Request.QueryString["Id"]));
                            lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        }

                     //}
                        else
                        {
                            lblError.Text = "No se pudo Insertar la Imagen de Adelantos por algun motivo, Verifique e intente nuevamente";
                            lblError.Visible = true;

                        }


                    }
                }
                else
                {
                    DocPagadas.Imagen = null;
                }
                Response.Redirect("FormListaSolicitud.aspx");
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