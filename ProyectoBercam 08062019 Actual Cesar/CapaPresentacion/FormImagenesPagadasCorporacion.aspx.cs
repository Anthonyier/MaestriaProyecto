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
    public partial class FormImagenesPagadasCorporacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesPagadas ObjImagen = new EntImagenesPagadas();
                ObjImagen = NegImgPagadas.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    //TextPagado.Text = ObjImagen.Nombre;
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
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            EntImagenesPagadas DocPagadas = new EntImagenesPagadas();
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
                    if (NegImgPagadas.InsertarImagen(DocPagadas) == 1)
                    {
                        NegConciliacionPorPagar.Pagado(int.Parse(Request.QueryString["Id"]));
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
            Response.Redirect("FormListaSolicitudCorp.aspx");
        }
    }
}