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

namespace CapaPresentacion
{
    public partial class FormImagenesCarroGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesCarroGuia ObjImagen = new EntImagenesCarroGuia();
                ObjImagen = NegImagenesCarroGuia.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    TextPagado.Text = ObjImagen.NombreDoc;
                }

            }
        }
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
        protected void BtnCarroGuia_Click(object sender, EventArgs e)
        {
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntImagenesCarroGuia Img = new EntImagenesCarroGuia();
            Img = NegImagenesCarroGuia.Download(Convert.ToInt32(Request.QueryString["Id"]));
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
             EntImagenesCarroGuia DocPagadas = new EntImagenesCarroGuia();
             EntConciliacionCarroGuia  ConcPagar = new EntConciliacionCarroGuia ();
             ConcPagar = NegConciliacionCarroGuia.ObtenerConcCarroGuia(Convert.ToInt32(Request.QueryString["Id"]));
             int IdPer = ConcPagar.IdPersona;
             int MaestProv = NegMaestroProveedor.EncontrarIdProveedor(ConcPagar.IdPersona);
             int IdPasivo = NegMaestroProveedor.EncontrarAnticipo(MaestProv);
             double MontoPorPagar = ConcPagar.Pagos;
            if (this.FileUpCarroguia.HasFile)
            {
                using (BinaryReader reader = new BinaryReader(this.FileUpCarroguia.PostedFile.InputStream))
                {
                    byte[] image = reader.ReadBytes(FileUpCarroguia.PostedFile.ContentLength);
                    DocPagadas.Imagen = image;
                    FileInfo Fi = new FileInfo(FileUpCarroguia.FileName);
                    DocPagadas.NombreDoc = Fi.Name;
                    DocPagadas.Ext = Fi.Extension;
                    DocPagadas.IdConciliacionCarroGuia = Convert.ToInt32(Request.QueryString["Id"]);
                    DocPagadas.FechaPago = Convert.ToDateTime(TextFecha.Text);
                }
                if (DocPagadas.Imagen != null)
                {
                    //if (NegImagenesCarroGuia.InsertarImagen(DocPagadas) == 1)
                    //{
                    //    NegConciliacionCarroGuia.Pagado(int.Parse(Request.QueryString["Id"]));
                    //    lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                    //    lblError.Visible = true;
                    //    Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                    //}
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    int IdUsuario = us.Id_Usuario;
                    int idTipoPago = 304;
                    EntMaestroProveedor MaPr = new EntMaestroProveedor();
                    MaPr.FechaAntcipo = DateTime.Parse(TextFecha.Text);
                    MaPr.IdPers = ConcPagar.IdPersona;
                    MaPr.IdUsuario = IdUsuario;
                    MaPr.MontoAnticipo = MontoPorPagar;
                    MaPr.IdAnticipo = 0;
                    MaPr.IdTipoPago = idTipoPago;
                    bool Ver = NegImagenesCarroGuia.MaestroProveedor(DateTime.Parse(TextFecha.Text), IdPer, IdUsuario, MontoPorPagar, DocPagadas, idTipoPago, IdPasivo);
                    if (Ver == true)
                    {
                        NegConciliacionCarroGuia.Pagado(int.Parse(Request.QueryString["Id"]));
                        lblError.Text = "Registro de Imagen guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Registro CI por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

                    }
                }
            }
            else
            {
                DocPagadas.Imagen = null;
            }
            Response.Redirect("FormListaSolicitudCarroGuia.aspx");
        }
    }
}