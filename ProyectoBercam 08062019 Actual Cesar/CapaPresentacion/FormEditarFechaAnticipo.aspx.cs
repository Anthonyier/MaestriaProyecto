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
    public partial class FormEditarFechaAnticipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ImagenId = Convert.ToInt32(Request.QueryString["Id"]);
                EntImagenesAnticipos ObjImagen = new EntImagenesAnticipos();
                ObjImagen = NegImagenesAnticipos.ConsultaImagen(ImagenId);
                if (ObjImagen != null)
                {
                    TextAnticip.Text = ObjImagen.NombreDoc;
                }
            }
        }

        protected void BtnAnticip_Click(object sender, EventArgs e)
        {
            int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
            EntImagenesAnticipos Img = new EntImagenesAnticipos();
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
            Response.AddHeader("Content-Disposition", "filename"+ Img.NombreDoc);
            Response.AddHeader("Content-Length", Document.Length.ToString());
            Response.BinaryWrite(Document);
            Response.Flush();
            Response.Close();
        }
        //protected void CalendarAnticipo_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (CalendarAnticipo.SelectedDate != null)
        //    {
        //        txtFechaAnticipo.Text = CalendarAnticipo.SelectedDate.ToString("d");
        //        CalendarAnticipo.Visible = false;
        //    }

        //}
        //protected void imgAnticipo_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (CalendarAnticipo.Visible)
        //    {
        //        CalendarAnticipo.Visible = false;
        //    }
        //    else
        //    {
        //        CalendarAnticipo.Visible = true;
        //    }
        //}
        //protected void BtnGuardar_Click(object sender, EventArgs e)
        //{
        //    int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
        //    int AnticipoId = NegImagenesAnticipos.ValorImagen(PersonaId);
        //    DateTime Fecha = Convert.ToDateTime(txtFechaAnticipo.Text);
        //    NegImagenesAnticipos.ModificarImagenAnticipo(AnticipoId, Fecha);
        //    NegImagenesAnticipos.ModificarFechaAnticipo(PersonaId, Fecha);
        //}
    }
}